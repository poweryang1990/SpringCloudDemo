using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using SpringCloudDemo.Common.zipkin;

[assembly: OwinStartup(typeof(SpringCloudDemo.Api.Startup))]

namespace SpringCloudDemo.Api
{
    public partial class Startup: CommonStartup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigurationZipkin(app);
        }
    }
}
