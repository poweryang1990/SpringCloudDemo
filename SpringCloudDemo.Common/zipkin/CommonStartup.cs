using System.Threading;
using Microsoft.Owin.BuilderProperties;
using Owin;
using zipkin4net;
using zipkin4net.Tracers.Zipkin;
using zipkin4net.Transport.Http;

namespace SpringCloudDemo.Common.zipkin
{
    public abstract class CommonStartup
    {
        public void ConfigurationZipkin(IAppBuilder appBuilder)
        {
            //Setup tracing
            TraceManager.SamplingRate = 1.0f;
            var logger = new ConsoleLogger();
            var httpSender = new HttpZipkinSender("http://192.168.200.122:9411", "application/json");
            var tracer = new ZipkinTracer(httpSender, new JSONSpanSerializer());
            TraceManager.RegisterTracer(tracer);
            TraceManager.Start(logger);
            //

            //Stop TraceManager on app dispose
            var properties = new AppProperties(appBuilder.Properties);
            var token = properties.OnAppDisposing;

            if (token != CancellationToken.None)
            {
                token.Register(() =>
                {
                    TraceManager.Stop();
                });
            }
            //

            // Setup Owin Middleware
            appBuilder.UseZipkinTracer(System.Configuration.ConfigurationManager.AppSettings["applicationName"]);
            //
        }

    }
}
