using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Integration.WebApi;
using SpringCloudDemo.Common;
using SpringCloudDemo.Common.Extensions;


namespace SpringCloudDemo.Api.App_Start
{
    public class IocConfig
    {
        private readonly IList<IModuleInitializer> _moduleList = new List<IModuleInitializer>();


        private readonly Lazy<IEnumerable<IModuleInitializer>> _lazyGetModuleInitializers;

        public IocConfig()
        {
            _lazyGetModuleInitializers = new Lazy<IEnumerable<IModuleInitializer>>(GetModuleInitializers);
        }
        public Container Init()
        {
            var container = new Container();

          
            container.Options.ConstructorResolutionBehavior = new LessConstructorBehavior();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            

            RegisterService(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            return container;
        }



        /// <summary>
        /// 此处用来注册一些公用的 service， 子类可以重写。
        /// </summary>
        protected  void RegisterService(Container container)
        {
            

            //Eureka 服务注册发现 IOC注入
            container.RegisterDiscoveryClient(ApplicationConfig.Configuration);



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
       

    }
}