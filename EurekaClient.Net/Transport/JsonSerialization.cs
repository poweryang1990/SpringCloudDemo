using Newtonsoft.Json;
using System.IO;

namespace EurekaClient.Net.Transport
{
    public class JsonSerialization
    {
        public static T Deserialize<T>(Stream stream)
        {
            using (JsonReader reader = new JsonTextReader(new StreamReader(stream)))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (T)serializer.Deserialize(reader, typeof(T));
            }
        }
    }
}
