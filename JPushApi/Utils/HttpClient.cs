using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JPush.Api.Utils
{
    public class HttpClient
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

        public void Post(String url, String authCode, String body)
        {
            this.sendRequest(url, WebRequestMethods.Http.Post, authCode, body);
        }

        public void Get()
        {
        }

        private ResponseWrapper sendRequest(String url, String method, String authCode, String body)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = _readTimeout;
            request.ContinueTimeout = _connectTimeout;
            request.Method = method;
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add(HttpRequestHeader.AcceptCharset, _charset);

            if (!String.IsNullOrEmpty(authCode))
            {
                request.Headers.Add("Authorization", "Basic " + authCode);
            }

            if (WebRequestMethods.Http.Post.Equals(method))
            {
                byte[] inputStream = Encoding.ASCII.GetBytes( body );
                request.ContentLength = inputStream.Length;
                using( Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(inputStream, 0, inputStream.Length);
                    reqStream.Close();
                }
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            return new ResponseWrapper( response );
        }

    }

}
