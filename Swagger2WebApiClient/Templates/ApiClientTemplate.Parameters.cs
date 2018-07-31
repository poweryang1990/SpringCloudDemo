using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swagger2WebApiClient.Models;
namespace Swagger2WebApiClient.Templates
{
    public partial class ApiClientTemplate
    {
        public ProxyDefinition ProxyDefinition { get; set; }

		public  ApiConfig Config { get; set; }

        public ApiClientTemplate(ProxyDefinition proxyDefinition, ApiConfig config)
        {
            ProxyDefinition = proxyDefinition;
            Config = config;
        }

    }
}
