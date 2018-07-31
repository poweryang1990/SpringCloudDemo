using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EurekaClient.Net;
using EurekaClient.Net.Transport;
using Microsoft.Extensions.Configuration;

namespace SpringCloudDemo.Common.Extensions
{
    public  static class RegisterEurekaClientExtensions
    {
        public static void RegisterDiscoveryClient(this Container container, IConfiguration configuration)
        {

            var clientConfig = new EurekaClientConfig();
            ConfigurationBinder.Bind(configuration.GetSection("eureka:client"), clientConfig);

            // Build Eureka instance info config from configuration
            var instConfig = new EurekaInstanceConfig();
            ConfigurationBinder.Bind(configuration.GetSection("eureka:instance"), instConfig);
            container.Register<IEurekaHttpClient>(()=>new EurekaHttpClient(clientConfig), Lifestyle.Scoped);

            container.Register<IEurekaClient>(() => new EurekaClient.Net.EurekaClient(container.GetInstance<IEurekaHttpClient>(), instConfig), Lifestyle.Singleton);
        }

        public static void RegisterCurrentService(this Container container)
        {
            container.GetInstance<IEurekaClient>().Register();
        }
    }
}
