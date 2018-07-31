using System;
using EurekaClient.Net.AppInfo;

namespace EurekaClient.Net
{
    public class StatusChangedArgs : EventArgs
    {
        public InstanceStatus Previous { get; private set; }

        public InstanceStatus Current { get; private set; }

        public string InstanceId { get; private set; }

        public StatusChangedArgs(InstanceStatus prev, InstanceStatus current, string instanceId)
        {
            Previous = prev;
            Current = current;
            InstanceId = instanceId;
        }
    }
}
