using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swagger2WebApiClient.Infrastructure;
using Swagger2WebApiClient.Models;

namespace Swagger2WebApiClient.Test
{
    [TestClass]
    public class ApiClientGenetatortTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            var apiConfig = new ApiConfig()
            {
                Namespace = "UOKO.Demo",
                SwaggerDocEndpoint = "http://localhost:5000/swagger/docs/v1",
                ServiceHost = "http://localhost:5000",
                ServiceName = "Demo",
                ServiceDiscoveryEndpoint = "http://localhost:8500"
            };
            var genetator=new ApiClientGenetator(apiConfig);
            var  result=genetator.Generate();
            var csFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, apiConfig.ServiceName+"WebApi") + ".cs";
            File.WriteAllText(csFilePath, result);
        }
    }
}
