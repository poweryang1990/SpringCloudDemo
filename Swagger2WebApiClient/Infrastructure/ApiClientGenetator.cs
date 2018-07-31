using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Swagger2WebApiClient.Models;
using Swagger2WebApiClient.Templates;

namespace Swagger2WebApiClient.Infrastructure
{
    public class ApiClientGenetator
    {
        private readonly ApiConfig _config;

        public ApiClientGenetator(ApiConfig config)
        {
            _config = config;
        }

        public string Generate()
        {
            var proxyDefinition = GetProxyDefinition();
            var template = new ApiClientTemplate(proxyDefinition, _config);
            var source = template.TransformText();
            return source;
        }

        private ProxyDefinition GetProxyDefinition()
        {
            var swaggerJsonUrl = _config.SwaggerDocEndpoint;
            using (var client = new HttpClient())
            {

                var response = client.GetAsync(swaggerJsonUrl).Result;
                response.EnsureSuccessStatusCode();
                var swaggerJson = response.Content.ReadAsStringAsync().Result;
                var parser = new SwaggerParser();
                var proxyDefinition = parser.ParseSwaggerDoc(swaggerJson, true);
                return proxyDefinition;
            }
        }
    }
}
