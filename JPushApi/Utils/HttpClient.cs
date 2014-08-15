using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JPush.Api.Utils
{
    public class HttpClient : IHttpClient
    {
        private String _charset = "UTF-8";
        private String _userAgent = "JPush-API-C#-Client";
        private int _readTimeout = 30;
        private int _connectTimeout = 5;
        private int _retry = 1;
        public String Charset { get; set; }
        public String UserAgent{ get; set; }
        public int ReadTimeout { get; set; }
        public int ConnectTimeout { get; set; }
        public int RetryTimes { get; set; }

        public void Post(String url, String authCoe, String body)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = HttpMethod.POST;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add( HttpRequestHeader.AcceptCharset, _charset );
        }

        public void Get()
        {
        }

        interface HttpMethod
        {
            public const string POST = "POST";
            public const string GET = "GET";
        }

        interface ApiResponseKey
        {
            public const string KEY_CONNECT_TIMED_OUT = "connect timed out";
            public const string KEY_READ_TIMED_OUT = "Read timed out";

        }
    }

}
