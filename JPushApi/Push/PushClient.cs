using JPush.Api.Properties;
using JPush.Api.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPush.Api.Push
{
    public class PushClient
    {
        private HttpClient _httpClient = null;
        private string _baseUrl = null;
        private string _appKey = null;
        private string _masterSecret = null;

        private int _maxRetryTimes = 3;
        private long _timeToLive = 86400;

        private bool _isEnableSSL = true;
        private bool _isApnsProduction = false;
        /// <summary>
        /// 此为JPush API Lib扩展属性。
        /// 最大重试次数，当前调用API失败时，自动重试的次数，设置为0将关闭重试，默认重试3次
        /// </summary>
        public int MaxRetryTimes
        {
            get { return _maxRetryTimes; }
            set { _maxRetryTimes = value; }
        }
        /// <summary>
        /// 消息保留时长，对应API的time_to_live参数，单位‘秒’，默认86400，即一天
        /// </summary>
        public long TTL
        {
            get { return _timeToLive; }
            set { _timeToLive = value; }
        }
        /// <summary>
        /// 是否使用SSL
        /// 调用JPush API是否使用https默认为true
        /// </summary>
        public bool IsEnableSSL
        {
            get { return _isEnableSSL; }
            set { _isEnableSSL = value; }
        }
        /// <summary>
        /// 是否iOS生产环境,默认开启
        /// </summary>
        public bool IsApnsProdution
        {
            get { return _isApnsProduction; }
            set { _isApnsProduction = value; }
        }

        public PushClient(String appKey, String masterSecret)
        {
            string apiBase = Resources.API_BASE;
            if ( !apiBase.EndsWith("/") ){
                apiBase += "/";
            }
            this._baseUrl = apiBase + Resources.API_PUSH;

            this._httpClient = new HttpClient();
        }

        public PushClient(String appKey, String masterSecret, int maxRetryTimes) : this(appKey, masterSecret)
        {

        }
        public PushClient(String appKey, String masterSecret, int readTimeout, int connectTimeout)
            : this(appKey, masterSecret)
        {
            this._httpClient.ConnectTimeout = connectTimeout;
            this._httpClient.ReadTimeout = readTimeout;
        }
        
        public PushClient(String appKey, String masterSecret, long timeToLive)
            : this(appKey, masterSecret)
        {
            this._timeToLive = timeToLive;
        }

    }
}
