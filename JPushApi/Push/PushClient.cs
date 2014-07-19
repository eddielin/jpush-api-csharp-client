using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPush.Api.Push
{
    class PushClient
    {
        private string appKey = null;
        private string masterSecret = null;
        private bool isEnableSSL = false;
        private bool isApnsProduction = false;

        private long timeToLive = 86400;
    }
}
