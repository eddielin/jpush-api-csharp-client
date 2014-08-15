using JPush.Api.Push;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPush.Api
{
    /// <summary>
    /// JPushClient - 封装了JPush API 3.0的所有功能
    /// </summary>
    /// <seealso cref="http://docs.jpush.cn"/>
    public class JPushClient
    {
        private PushClient _pushCli = null;

        private static TraceSource SRC = new TraceSource("JPushSource");
        public JPushClient(String appKey, String masterSecret)
        {
            _pushCli = new PushClient(appKey, masterSecret);
        }

        public JPushClient(String appKey, String masterSecret, int maxRetryTimes)
        {
            _pushCli = new PushClient(appKey, masterSecret) { MaxRetryTimes = maxRetryTimes };
        }
    }
}
