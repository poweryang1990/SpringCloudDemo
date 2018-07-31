using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EurekaClient.Net.AppInfo;

namespace EurekaClient.Net
{
    public class EurekaServiceInfo
    {
        private InstanceInfo _info;

        internal EurekaServiceInfo(InstanceInfo info)
        {
            this._info = info;
        }

        public string GetHost()
        {
            return _info.HostName;
        }

        public bool IsSecure
        {
            get
            {
                return _info.IsSecurePortEnabled;
            }
        }

        public IDictionary<string, string> Metadata
        {
            get
            {
                return _info.Metadata;
            }
        }

        public int Port
        {
            get
            {
                if (IsSecure)
                {
                    return _info.SecurePort;
                }

                return _info.Port;
            }
        }

        public string ServiceId
        {
            get
            {
                return _info.AppName;
            }
        }

        public Uri Uri
        {
            get
            {
                string scheme = IsSecure ? "https" : "http";
                return new Uri(scheme + "://" + GetHost() + ":" + Port);
            }
        }

        public string Host => GetHost();

    }
}
