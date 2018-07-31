using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector.Advanced;

namespace SpringCloudDemo.Common
{
    public class LessConstructorBehavior : IConstructorResolutionBehavior
    {
        public ConstructorInfo GetConstructor(Type serviceType, Type implementationType)
        {
            return implementationType.GetConstructors().OrderBy(p => p.GetParameters().Length).FirstOrDefault();
        }
    }
}
