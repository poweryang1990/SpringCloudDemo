using System;
using System.IO;
using System.Net;
using EurekaClient.Net.AppInfo;
using EurekaClient.Net.Transport;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EurekaClient.Net.UnitTest
{
    [TestClass]
    public class EurekaHttpClientTest
    {
        public static IConfigurationRoot Configuration { get; set; }
        [TestInitialize]
        public void SetUp()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(GetContentRoot())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

            Configuration = builder.Build();
        }
        [TestMethod]
        public void TestRegister()
        {

           var tmp= Uri.EscapeDataString("AA-BB:DD CC?");
            var clientConfig = new EurekaClientConfig();
            ConfigurationBinder.Bind(Configuration.GetSection("eureka:client"), clientConfig);

            // Build Eureka instance info config from configuration
            var instConfig = new EurekaInstanceConfig();
            ConfigurationBinder.Bind(Configuration.GetSection("eureka:instance"), instConfig);

            IEurekaHttpClient eurekaHttpClient=new EurekaHttpClient(clientConfig);
            var  result=eurekaHttpClient.RegisterAsync(InstanceInfo.FromInstanceConfig(instConfig)).ConfigureAwait(false).GetAwaiter().GetResult();

        }

        public static string GetContentRoot()
        {
            var basePath = (string)AppDomain.CurrentDomain.GetData("APP_CONTEXT_BASE_DIRECTORY") ??
                           AppDomain.CurrentDomain.BaseDirectory;
            return Path.GetFullPath(basePath);
        }
    }
}
