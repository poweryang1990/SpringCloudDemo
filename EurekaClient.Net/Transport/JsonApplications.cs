using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EurekaClient.Net.Transport
{
    public class JsonApplications
    {
        [JsonProperty("apps__hashcode")]
        public string AppsHashCode { get;  set; }

        [JsonProperty("versions__delta")]
        public long VersionDelta { get;  set; }

        [JsonProperty("application")]
        [JsonConverter(typeof(JsonApplicationConverter))]
        public IList<JsonApplication> Applications { get; set; }

        public JsonApplications()
        {
        }

        public static JsonApplications Deserialize(Stream stream)
        {
            return JsonSerialization.Deserialize<JsonApplications>(stream);
        }
    }
}
