using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Refit;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

using SpringCloudDemo.Common;
using SpringCloudDemo.Common.Extensions;
using UOKO.Demo.Api;

namespace SpringCloudDemo.Mvc.App_Start
{
    public class IocConfig
    {
        private readonly IList<IModuleInitializer> _moduleList = new List<IModuleInitializer>();


        private readonly Lazy<IEnumerable<IModuleInitializer>> _lazyGetModuleInitializers;

        public IocConfig()
        {
            _lazyGetModuleInitializers = new Lazy<IEnumerable<IModuleInitializer>>(GetModuleInitializers);
        }
        public void Init()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Options.ConstructorResolutionBehavior = new LessConstructorBehavior();

            RegisterService(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }



        /// <summary>
        /// 此处用来注册一些公用的 service， 子类可以重写。
        /// </summary>
        protected  void RegisterService(Container container)
        {

            //Eureka 服务注册发现 IOC注入
            container.RegisterDiscoveryClient(ApplicationConfig.Configuration);
            container.Register(()=> RestService.For<IUserWebApi>("http://localhost:5000/"),Lifestyle.Scoped);
            _lazyGetModuleInitializers.Value.ToList().ForEach(x => x.LoadIoCSetting(container));
        }

        private IEnumerable<IModuleInitializer> GetModuleInitializers()
        {
            AddModuleInitializer(new CommonModuleInitializer());
            return _moduleList;
        }
        protected void AddModuleInitializer(IModuleInitializer module)
        {
            if (module == null)
            {
                return;
            }

            if (_moduleList.Any(item => item.GetType() == module.GetType()))
            {
                return;
            }

            _moduleList.Add(module);
        }
        class LessConstructorBehavior : IConstructorResolutionBehavior
        {
            public ConstructorInfo GetConstructor(Type serviceType, Type implementationType)
            {
                return implementationType.GetConstructors().OrderBy(p => p.GetParameters().Length).FirstOrDefault();
            }
        }
    }
}