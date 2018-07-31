using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EurekaClient.Net.Task
{
    public class TimedTask
    {
        public string Name { get; private set; }

        public Action Task { get; private set; }

        private int _taskRunning;

        public TimedTask(string name, Action task)
        {
            Name = name;
            Task = task;
            _taskRunning = 0;
        }

        public void Run(object state)
        {
            if (Interlocked.CompareExchange(ref _taskRunning, 1, 0) == 0)
            {
                try
                {
                    Task();
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message, ex);
                }

                Interlocked.Exchange(ref _taskRunning, 0);
            }
            else
            {
                Trace.TraceInformation("already running");
            }
        }
    }
}
