using System.Collections.Generic;
using System.Threading.Tasks;
using EurekaClient.Net.AppInfo;

namespace EurekaClient.Net
{
   
    public interface IEurekaClient
    {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="info"></param>
        void Register();
        /// <summary>
        /// 获取所有服务
        /// </summary>
        IList<string> Services { get; }
        /// <summary>
        /// 获取指定服务
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        IList<EurekaServiceInfo> GetInstances(string serviceId);
    }
}