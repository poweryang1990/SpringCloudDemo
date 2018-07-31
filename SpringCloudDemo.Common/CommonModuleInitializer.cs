using SimpleInjector;
using SpringCloudDemo.Common.Service;

namespace SpringCloudDemo.Common
{
    public class CommonModuleInitializer:IModuleInitializer
    {
        public void LoadIoCSetting(Container container)
        {

            container.Register(typeof(IUserService), typeof(UserService), Lifestyle.Scoped);
        }
    }
}