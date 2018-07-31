using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swagger2WebApiClient.Models
{
    public class ApiConfig
    {
        public const string JsonConfigFileName = "ApiConfig.json";

        public  string Namespace { get; set; }
        public  string SwaggerDocEndpoint { get; set; }
        public  string ServiceDiscoveryEndpoint { get; set; }
        public  string ServiceName { get; set; }

        public string ServiceHost { get; set; }
    }
}
