
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using EurekaClient.Net.AppInfo;

namespace EurekaClient.Net
{
    public class EurekaInstanceConfig : IEurekaInstanceConfig
    {
      
        public const int Default_NonSecurePort = 80;
        public const int Default_SecurePort = 443;
        public const int Default_LeaseRenewalIntervalInSeconds = 30;
        public const int Default_LeaseExpirationDurationInSeconds = 90;
        public const string Default_Appname = "unknown";
        public const string Default_StatusPageUrlPath = "/Status";
        public const string Default_HomePageUrlPath = "/";
        public const string Default_HealthCheckUrlPath = "/healthcheck";

        protected string _thisHostAddress;
        protected string _thisHostName;

        public EurekaInstanceConfig()
        {
            _thisHostName = GetHostName(true);
            _thisHostAddress = GetHostAddress(true);

            IsInstanceEnabledOnInit = false;
            NonSecurePort = Default_NonSecurePort;
            SecurePort = Default_SecurePort;
            IsNonSecurePortEnabled = true;
            SecurePortEnabled = false;
            LeaseRenewalIntervalInSeconds = Default_LeaseRenewalIntervalInSeconds;
            LeaseExpirationDurationInSeconds = Default_LeaseExpirationDurationInSeconds;
            VirtualHostName = _thisHostName + ":" + NonSecurePort;
            SecureVirtualHostName = _thisHostName + ":" + SecurePort;
            IpAddress = _thisHostAddress;
            AppName = Default_Appname;
            StatusPageUrlPath = Default_StatusPageUrlPath;
            HomePageUrlPath = Default_HomePageUrlPath;
            HealthCheckUrlPath = Default_HealthCheckUrlPath;
            MetadataMap = new Dictionary<string, string>();
            DataCenterInfo = new DataCenterInfo(DataCenterName.MyOwn);
            PreferIpAddress = false;
        }

        // eureka:instance:instanceId, 
        public  string InstanceId { get; set; }

        // eureka:instance:appName,
        public  string AppName { get; set; }

        // eureka:instance:securePort
        public  int SecurePort { get; set; }

        // eureka:instance:securePortEnabled
        public  bool SecurePortEnabled { get; set; }

        // eureka:instance:leaseRenewalIntervalInSeconds
        public  int LeaseRenewalIntervalInSeconds { get; set; }

        // eureka:instance:leaseExpirationDurationInSeconds
        public  int LeaseExpirationDurationInSeconds { get; set; }

        // eureka:instance:asgName, null
        public  string ASGName { get; set; }

        // eureka:instance:metadataMap
        public  IDictionary<string, string> MetadataMap { get; set; }

        // eureka:instance:statusPageUrlPath
        public  string StatusPageUrlPath { get; set; }

        // eureka:instance:statusPageUrl
        public  string StatusPageUrl { get; set; }

        // eureka:instance:homePageUrlPath
        public  string HomePageUrlPath { get; set; }

        // eureka:instance:homePageUrl
        public  string HomePageUrl { get; set; }

        // eureka:instance:healthCheckUrlPath
        public  string HealthCheckUrlPath { get; set; }

        // eureka:instance:healthCheckUrl
        public  string HealthCheckUrl { get; set; }

        // eureka:instance:secureHealthCheckUrl
        public  string SecureHealthCheckUrl { get; set; }

        // eureka:instance:preferIpAddress
        public  bool PreferIpAddress { get; set; }

        // eureka:instance:hostName
        public  string HostName
        {
            get
            {
                return _thisHostName;
            }

            set
            {
                _thisHostName = value;
            }
        }

        public  string IpAddress { get; set; }

        public  string AppGroupName { get; set; }

        public  bool IsInstanceEnabledOnInit { get; set; }

        public  int NonSecurePort { get; set; }

        public  bool IsNonSecurePortEnabled { get; set; }

        public  string VirtualHostName { get; set; }

        public  string SecureVirtualHostName { get; set; }

        public  IDataCenterInfo DataCenterInfo { get; set; }

        public  string[] DefaultAddressResolutionOrder { get; set; }

        public  string GetHostName(bool refresh)
        {
            if (refresh || string.IsNullOrEmpty(_thisHostName))
            {
                _thisHostName = ResolveHostName();
            }

            return _thisHostName;
        }

        public  string GetHostAddress(bool refresh)
        {
            if (refresh || string.IsNullOrEmpty(_thisHostAddress))
            {
                string hostName = GetHostName(refresh);
                if (!string.IsNullOrEmpty(hostName))
                {
                    _thisHostAddress = ResolveHostAddress(hostName);
                }
            }

            return _thisHostAddress;
        }

        protected  string ResolveHostAddress(string hostName)
        {
            string result = null;
            try
            {
                var results = Dns.GetHostAddresses(hostName);
                if (results != null && results.Length > 0)
                {
                    foreach (var addr in results)
                    {
                        if (addr.AddressFamily.Equals(AddressFamily.InterNetwork))
                        {
                            result = addr.ToString();
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Ignore
            }

            return result;
        }

        protected  string ResolveHostName()
        {
            string result = null;
            try
            {
                result = Dns.GetHostName();
                if (!string.IsNullOrEmpty(result))
                {
                    var response = Dns.GetHostEntry(result);
                    if (response != null)
                    {
                        return response.HostName;
                    }
                }
            }
            catch (Exception)
            {
                // Ignore
            }

            return result;
        }
    }
}
