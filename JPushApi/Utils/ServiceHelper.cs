using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JPush.Api.Utils
{
    class ServiceHelper
    {
        private static Regex APPKEY_PATTERN = new Regex("[^a-zA-A0-9]");

        private const String BASIC_PREFIX = "Basic ";

        private static Random RANDOM = new Random((int)ServiceHelper.GetTimeStamp(true));

        private const int MAX_BADGE_NUMBER = 99999;
        private const int SENDNO_MIN = 100000;

        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <param name="bflag">为真时获取10位时间戳,为假时获取13位时间戳.</param>
        /// <returns></returns>
        public static long GetTimeStamp(bool bflag = true)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long ret = 0;
            if (bflag)
                ret = Convert.ToInt64(ts.TotalSeconds);
            else
                ret = Convert.ToInt64(ts.TotalMilliseconds);

            return ret;
        }

        /// <summary>
        /// 校验badge参数是否在合法范围内
        /// </summary>
        /// <param name="badge">iOS badge参数</param>
        /// <returns></returns>
        public static bool IsValidIntBadge(int badge)
        {
            return badge >= 0 && badge <= MAX_BADGE_NUMBER;
        }

        public static int GenerateSendno()
        {
            return RANDOM.Next(SENDNO_MIN, Int32.MaxValue);
        }

        public static string GetBasicAuthorization(string username, string password)
        {
            string encodeKey = username + ":" + password;

            return BASIC_PREFIX + Convert.ToBase64String(Encoding.UTF8.GetBytes(encodeKey));
        }

        public static bool CheckBasic(string appKey, string masterSecret)
        {
            return !(appKey.Length != 24
                || masterSecret.Length != 24
                || APPKEY_PATTERN.IsMatch(appKey)
                || APPKEY_PATTERN.IsMatch(masterSecret));
        }
    }
}
