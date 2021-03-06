﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurekaClient.Net.Util
{
    public static class DateTimeConversions
    {
        private static DateTime baseTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long ToJavaMillis(DateTime dt)
        {
            if (dt.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException("Kind != UTC");
            }

            if (dt.Ticks <= 0)
            {
                return 0;
            }

            long javaTicks = dt.Ticks - baseTime.Ticks;
            return javaTicks / 10000;
        }

        public static DateTime FromJavaMillis(long javaMillis)
        {
            long dotNetTicks = (javaMillis * 10000) + baseTime.Ticks;
            return new DateTime(dotNetTicks, DateTimeKind.Utc);
        }
    }
}
