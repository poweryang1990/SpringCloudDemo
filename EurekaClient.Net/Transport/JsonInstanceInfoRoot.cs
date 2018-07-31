using Newtonsoft.Json;
using System.IO;

namespace EurekaClient.Net.Transport
{
    public class JsonInstanceInfoRoot
    {
        [JsonProperty("instance")]
        public JsonInstanceInfo Instance { get; private set; }

        public JsonInstanceInfoRoot(JsonInstanceInfo info)
        {
            Instance = info;
        }

        public static JsonInstanceInfoRoot Deserialize(Stream stream)
        {
            return JsonSerialization.Deserialize<JsonInstanceInfoRoot>(stream);
        }
    }
}
