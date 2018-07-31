using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using EurekaClient.Net.AppInfo;
using EurekaClient.Net.Task;
using EurekaClient.Net.Transport;

namespace EurekaClient.Net
{
    public class EurekaClient : IEurekaClient
    {
        private Timer _heartBeatTimer;

        protected volatile Applications _localRegionApps;

        private IEurekaHttpClient _httpClient;
        private IEurekaInstanceConfig _instanceConfig;
        public EurekaClient(IEurekaHttpClient httpClient, IEurekaInstanceConfig instanceConfig)
        {
            _httpClient = httpClient;
            _instanceConfig = instanceConfig;
        }
        public void Register()
        {
            var instance = InstanceInfo.FromInstanceConfig(_instanceConfig);
            if (instance!=null)
            {
                _httpClient.RegisterAsync(instance).ConfigureAwait(false).GetAwaiter().GetResult();
                //开启心跳发送
                var intervalInMilli = instance.LeaseInfo.RenewalIntervalInSecs * 1000;
                _heartBeatTimer = StartTimer("HeartBeat", intervalInMilli, this.HeartBeatTask);
            }
            
        }

        private void HeartBeatTask()
        {
            var instance = InstanceInfo.FromInstanceConfig(_instanceConfig);
            var resp = _httpClient.SendHeartBeatAsync(instance.AppName, instance.InstanceId, instance, InstanceStatus.UNKNOWN)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            if (resp.StatusCode == HttpStatusCode.NotFound)
            {
                _httpClient.RegisterAsync(instance).ConfigureAwait(false).GetAwaiter().GetResult();
            }
        }

        public IList<string> Services => GetServices();

        private IList<string> GetServices()
        {
            Applications applications = _httpClient.GetApplicationsAsync().ConfigureAwait(false).GetAwaiter().GetResult().Response;
            if (applications == null)
            {
                return new List<string>();
            }

            IList<Application> registered = applications.GetRegisteredApplications();
            List<string> names = new List<string>();
            foreach (Application app in registered)
            {
                if (app.Instances.Count == 0)
                {
                    continue;
                }

                names.Add(app.Name.ToLowerInvariant());
            }

            return names;
        }

        public IList<EurekaServiceInfo> GetInstances(string serviceId)
        {
            throw new System.NotImplementedException();
        }

        private Timer StartTimer(string name, int interval, Action task)
        {
            var timedTask = new TimedTask(name, task);
            var timer = new Timer(timedTask.Run, null, interval, interval);
            return timer;
        }
    }
}