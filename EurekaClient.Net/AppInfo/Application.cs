﻿
using EurekaClient.Net.Transport;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace EurekaClient.Net.AppInfo
{
    public class Application
    {
        private ConcurrentDictionary<string, InstanceInfo> _instanceMap = new ConcurrentDictionary<string, InstanceInfo>();

        public string Name { get; internal set; }

        public int Count
        {
            get
            {
                return _instanceMap.Count;
            }
        }

        public IList<InstanceInfo> Instances
        {
            get
            {
                return new List<InstanceInfo>(_instanceMap.Values);
            }
        }

        public InstanceInfo GetInstance(string instanceId)
        {
            _instanceMap.TryGetValue(instanceId, out InstanceInfo result);
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Application[");
            sb.Append("Name=" + Name);
            sb.Append(",Instances=");
            foreach (var inst in Instances)
            {
                sb.Append(inst.ToString());
                sb.Append(",");
            }

            sb.Append("]");
            return sb.ToString();
        }

        public Application(string name)
        {
            Name = name;
        }

        public Application(string name, IList<InstanceInfo> instances)
        {
            Name = name;
            foreach (InstanceInfo info in instances)
            {
                Add(info);
            }
        }

        public void Add(InstanceInfo info)
        {
            _instanceMap[info.InstanceId] = info;
        }

        public void Remove(InstanceInfo info)
        {
            _instanceMap.TryRemove(info.InstanceId, out InstanceInfo removed);
        }

        public ConcurrentDictionary<string, InstanceInfo> InstanceMap
        {
            get
            {
                return _instanceMap;
            }
        }

        public static Application FromJsonApplication(JsonApplication japp)
        {
            if (japp == null)
            {
                return null;
            }

            Application app = new Application(japp.Name);
            if (japp.Instances != null)
            {
                foreach (var instance in japp.Instances)
                {
                    var inst = InstanceInfo.FromJsonInstance(instance);
                    app.Add(inst);
                }
            }

            return app;
        }
    }
}
