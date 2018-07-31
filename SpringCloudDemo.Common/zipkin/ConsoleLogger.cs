using System;
using zipkin4net;

namespace SpringCloudDemo.Common.zipkin
{
    class ConsoleLogger : ILogger
    {
        public void LogError(string message)
        {
            Console.Error.WriteLine(message);
        }

        public void LogInformation(string message)
        {
            Console.WriteLine(message);
        }

        public void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
