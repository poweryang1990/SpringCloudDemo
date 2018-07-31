using Newtonsoft.Json;
using System.IO;

namespace EurekaClient.Net.Transport
{
    public class JsonApplicationsRoot
    {
        [JsonProperty("applications")]
        public JsonApplications Applications { get; set; }

        public static JsonApplicationsRoot Deserialize(Stream stream)
        {
            return JsonSerialization.Deserialize<JsonApplicationsRoot>(stream);
        }
    }
}
