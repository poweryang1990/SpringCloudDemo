using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EurekaClient.Net.Transport
{
    public class JsonApplication
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("instance")]
        [JsonConverter(typeof(JsonInstanceInfoConverter))]
        public IList<JsonInstanceInfo> Instances { get; set; }

        [JsonConstructor]
        public JsonApplication()
        {
        }

        public static JsonApplication Deserialize(Stream stream)
        {
            return JsonSerialization.Deserialize<JsonApplication>(stream);
        }
    }
}
