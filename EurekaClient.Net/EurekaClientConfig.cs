namespace EurekaClient.Net
{
    public class EurekaClientConfig : IEurekaClientConfig
    {
        public const int Default_RegistryFetchIntervalSeconds = 30;
        public const int Default_InstanceInfoReplicationIntervalSeconds = 40;
        public const int Default_EurekaServerConnectTimeoutSeconds = 5;
        public const string Default_ServerServiceUrl = "http://localhost:8761/eureka/";

        public EurekaClientConfig()
        {
            RegistryFetchIntervalSeconds = Default_RegistryFetchIntervalSeconds;
            InstanceInfoReplicationIntervalSeconds = Default_InstanceInfoReplicationIntervalSeconds;
            ShouldGZipContent = true;
            EurekaServerConnectTimeoutSeconds = Default_EurekaServerConnectTimeoutSeconds;
            ShouldRegisterWithEureka = true;
            AllowRedirects = false;
            ShouldDisableDelta = false;
            ShouldFilterOnlyUpInstances = true;
            ShouldFetchRegistry = true;
            ShouldOnDemandUpdateStatusChange = true;
            EurekaServerServiceUrls = Default_ServerServiceUrl;
            ValidateCertificates = true;
        }

        // Configuration property: eureka:client:registryFetchIntervalSeconds
        public int RegistryFetchIntervalSeconds { get; set; }

        // Configuration property: eureka:client:instanceInfoReplicationIntervalSeconds
        public int InstanceInfoReplicationIntervalSeconds { get; set; }

        // Configuration property: eureka:client:shouldRegisterWithEureka
        public bool ShouldRegisterWithEureka { get; set; }

        // Configuration property: eureka:client:allowRedirects
        public bool AllowRedirects { get; set; }

        // Configuration property: eureka:client:shouldDisableDelta
        public bool ShouldDisableDelta { get; set; }

        // Configuration property: eureka:client:shouldFilterOnlyUpInstances
        public bool ShouldFilterOnlyUpInstances { get; set; }

        // Configuration property: eureka:client:shouldFetchRegistry
        public bool ShouldFetchRegistry { get; set; }

        // Configuration property: eureka:client:registryRefreshSingleVipAddress
        public string RegistryRefreshSingleVipAddress { get; set; }

        // Configuration property: eureka:client:shouldOnDemandUpdateStatusChange
        public bool ShouldOnDemandUpdateStatusChange { get; set; }

        // Configuration property: eureka:client:enabled
        public bool Enabled { get; set; } = true;

        public string EurekaServerServiceUrls { get; set; }

        public int EurekaServerConnectTimeoutSeconds { get; set; }

        public string ProxyHost { get; set; }

        public int ProxyPort { get; set; }

        public string ProxyUserName { get; set; }

        public string ProxyPassword { get; set; }

        public bool ShouldGZipContent { get; set; }

        public bool ValidateCertificates { get; set; }
    }
}
