using EurekaClient.Net.Transport;
using System;

namespace EurekaClient.Net.AppInfo
{
    public class DataCenterInfo : IDataCenterInfo
    {
        public DataCenterName Name { get; private set; }

        public DataCenterInfo(DataCenterName name)
        {
            Name = name;
        }

        public static IDataCenterInfo FromJson(JsonInstanceInfo.JsonDataCenterInfo jcenter)
        {
            if (DataCenterName.MyOwn.ToString().Equals(jcenter.Name))
            {
                return new DataCenterInfo(DataCenterName.MyOwn);
            }
            else if (DataCenterName.Amazon.ToString().Equals(jcenter.Name))
            {
                return new DataCenterInfo(DataCenterName.Amazon);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Datacenter name");
            }
        }

        public JsonInstanceInfo.JsonDataCenterInfo ToJson()
        {
            // TODO: Other datacenters @class settings?
            return new JsonInstanceInfo.JsonDataCenterInfo(
                "com.netflix.appinfo.InstanceInfo$DefaultDataCenterInfo",
                this.Name.ToString());
        }
    }
}
