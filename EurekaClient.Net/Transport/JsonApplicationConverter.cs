using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using EurekaClient.Net.Transport;

namespace EurekaClient.Net.Transport
{
    public class JsonApplicationConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IList<JsonApplication>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<JsonApplication> result = null;
            try
            {
                if (reader.TokenType == JsonToken.StartArray)
                {
                    result = (List<JsonApplication>)serializer.Deserialize(reader, typeof(List<JsonApplication>));
                }
                else
                {
                    JsonApplication singleInst = (JsonApplication)serializer.Deserialize(reader, typeof(JsonApplication));
                    if (singleInst != null)
                    {
                        result = new List<JsonApplication>
                        {
                            singleInst
                        };
                    }
                }
            }
            catch (Exception)
            {
                result = new List<JsonApplication>();
            }

            if (result == null)
            {
                result = new List<JsonApplication>();
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
