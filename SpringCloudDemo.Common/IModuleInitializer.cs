using SimpleInjector;

namespace SpringCloudDemo.Common
{
    public interface IModuleInitializer
    {
        /// <summary>
        /// 加载ioc配置
        /// </summary>
        /// <param name="container"></param>
        void LoadIoCSetting(Container container);
    }
}