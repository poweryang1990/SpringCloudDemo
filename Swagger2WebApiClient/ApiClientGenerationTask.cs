using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Swagger2WebApiClient.Infrastructure;
using Swagger2WebApiClient.Models;

namespace Swagger2WebApiClient
{
    public class ApiClientGenerationTask
    {
        public ApiClientGenerationTask(string rootPath)
        {
            Root = rootPath;
        }

        public string Root { get; set; }

        public void Generate()
        {
            var jsonConfigFile = Path.Combine(Root, ApiConfig.JsonConfigFileName);
            ApiConfig jsonConfig;

            using (var sr = new StreamReader(jsonConfigFile))
            {
                jsonConfig = JsonConvert.DeserializeObject<ApiConfig>(sr.ReadToEnd());
            }
            var genetator = new ApiClientGenetator(jsonConfig);
            var source = genetator.Generate();
            File.WriteAllText(Path.Combine(Root, jsonConfig.Name) + ".cs", source);

        }
    }
}
