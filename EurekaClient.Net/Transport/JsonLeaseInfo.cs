using Newtonsoft.Json;
using System.IO;

namespace EurekaClient.Net.Transport
{
    public class JsonLeaseInfo
    {
        [JsonProperty("renewalIntervalInSecs")]
        public int RenewalIntervalInSecs { get; set; }

        [JsonProperty("durationInSecs")]
        public int DurationInSecs { get; set; }

        [JsonProperty("registrationTimestamp")]
        public long RegistrationTimestamp { get; set; }

        [JsonProperty("lastRenewalTimestamp")]
        public long LastRenewalTimestamp { get; set; }

        [JsonProperty("renewalTimestamp")]
        public long LastRenewalTimestampLegacy { get; set; }

        [JsonProperty("evictionTimestamp")]
        public long EvictionTimestamp { get; set; }

        [JsonProperty("serviceUpTimestamp")]
        public long ServiceUpTimestamp { get; set; }

        public static JsonLeaseInfo Deserialize(Stream stream)
        {
            return JsonSerialization.Deserialize<JsonLeaseInfo>(stream);
        }
    }
}
