using System;
using System.Diagnostics;
using EurekaClient.Net.AppInfo;

namespace EurekaClient.Net
{
    public class ApplicationInfoManager
    {
        protected ApplicationInfoManager()
        {
        }

        protected static ApplicationInfoManager _instance = new ApplicationInfoManager();

        private object _statusChangedLock = new object();

        public static ApplicationInfoManager Instance
        {
            get
            {
                return _instance;
            }
        }

        public virtual IEurekaInstanceConfig InstanceConfig { get; protected internal set; }

        public virtual InstanceInfo InstanceInfo { get; protected internal set; }

        public virtual event StatusChangedHandler StatusChangedEvent;

        public virtual InstanceStatus InstanceStatus
        {
            get
            {
                if (InstanceInfo == null)
                {
                    return InstanceStatus.UNKNOWN;
                }

                return InstanceInfo.Status;
            }

            set
            {
                if (InstanceInfo == null)
                {
                    return;
                }

                lock (_statusChangedLock)
                {
                    InstanceStatus prev = InstanceInfo.Status;
                    if (prev != value)
                    {
                        InstanceInfo.Status = value;
                        if (StatusChangedEvent != null)
                        {
                            try
                            {
                                StatusChangedEvent(this, new StatusChangedArgs(prev, value, InstanceInfo.InstanceId));
                            }
                            catch (Exception e)
                            {
                               Trace.TraceError("StatusChangedEvent Exception:", e);
                            }
                        }
                    }
                }
            }
        }

        public virtual void Initialize(IEurekaInstanceConfig instanceConfig)
        {
            InstanceConfig = instanceConfig ?? throw new ArgumentNullException(nameof(instanceConfig));
            InstanceInfo = InstanceInfo.FromInstanceConfig(instanceConfig);
        }

        public virtual void RefreshLeaseInfo()
        {
            if (InstanceInfo == null || InstanceConfig == null)
            {
                return;
            }

            if (InstanceInfo.LeaseInfo == null)
            {
                return;
            }

            if (InstanceInfo.LeaseInfo.DurationInSecs != InstanceConfig.LeaseExpirationDurationInSeconds ||
                InstanceInfo.LeaseInfo.RenewalIntervalInSecs != InstanceConfig.LeaseRenewalIntervalInSeconds)
            {
                LeaseInfo newLease = new LeaseInfo()
                {
                    DurationInSecs = InstanceConfig.LeaseExpirationDurationInSeconds,
                    RenewalIntervalInSecs = InstanceConfig.LeaseRenewalIntervalInSeconds
                };
                InstanceInfo.LeaseInfo = newLease;
                InstanceInfo.IsDirty = true;
            }
        }
    }

    public delegate void StatusChangedHandler(object sender, StatusChangedArgs args);
}
