using System.IO;

namespace EurekaClient.Net.Transport
{
    public class JsonApplicationRoot
    {
        public JsonApplication Application { get; set; }

        public static JsonApplicationRoot Deserialize(Stream stream)
        {
            return JsonSerialization.Deserialize<JsonApplicationRoot>(stream);
        }
    }
}
