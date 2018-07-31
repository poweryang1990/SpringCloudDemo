using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EurekaClient.Net.Transport
{
    public class JsonInstanceInfoConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IList<JsonInstanceInfo>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<JsonInstanceInfo> result = null;
            try
            {
                if (reader.TokenType == JsonToken.StartArray)
                {
                    result = (List<JsonInstanceInfo>)serializer.Deserialize(reader, typeof(List<JsonInstanceInfo>));
                }
                else
                {
                    JsonInstanceInfo singleInst = (JsonInstanceInfo)serializer.Deserialize(reader, typeof(JsonInstanceInfo));
                    if (singleInst != null)
                    {
                        result = new List<JsonInstanceInfo>
                        {
                            singleInst
                        };
                    }
                }
            }
            catch (Exception)
            {
                result = new List<JsonInstanceInfo>();
            }

            if (result == null)
            {
                result = new List<JsonInstanceInfo>();
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
