using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace JPush.Api.Utils
{
    class ResponseWrapper
    {
        private const int RESPONSE_CODE_NONE = -1;

        private bool isServerResponse = true;
        private int responseCode = RESPONSE_CODE_NONE;
        private String responseContent = null;
        private ErrorObject error;
        private int rateLimitQuota;
        private int rateLimitRemaining;
        private int rateLimitReset;

        public int ResponseCode { get { return responseCode; } }
        public String ResponseContent { get { return responseContent; } }
        public int RateLimitQuota { get { return rateLimitQuota; } }
        public int RateLimitRemaining { get { return rateLimitRemaining; } }
        public int RateLimitReset { get { return rateLimitReset; } }

        public bool IsServerResponse { get { return isServerResponse; } }

        public ResponseWrapper(HttpWebResponse response)
        {

            HttpStatusCode statusCode = response.StatusCode;

            if (statusCode == HttpStatusCode.OK)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    this.responseContent = reader.ReadToEnd();
                    error = JsonConvert.DeserializeObject<ErrorObject>(this.responseContent);
                }
            }

            try
            {
                //this.rateLimitQuota = Int32.Parse(response.GetResponseHeader(ResponseHeaderKeyDefined.QUOTA_RATE.ToString()));
                //this.rateLimitRemaining = Int32.Parse(response.GetResponseHeader(ResponseHeaderKeyDefined.REMAINING_RATE.ToString()));
                //this.rateLimitReset = Int32.Parse(response.GetResponseHeader(ResponseHeaderKeyDefined.RESET_RATE.ToString()));
            }
            catch (Exception e)
            {
                
            }

            isServerResponse = !(responseCode == 0 || error == null || error.Error.Code == 0);
        }


    }
    public class ErrorObject
    {
        private long msg_id;
        private ErrorEntity error;

        public long MsgId { get; set; }
        public ErrorEntity Error { get; set; }
    }

    public class ErrorEntity
    {
        private int code;
        private String message;

        public int Code { get; set; }
        public String Measage { get; set; }

    }
    public enum ResponseHeaderKeyDefined
    {
        //QUOTA_RATE = "X-Rate-Limit-Limit",
        //REMAINING_RATE = "X-Rate-Limit-Remaining",
        //RESET_RATE = "X-Rate-Limit-Reset"
    }
}
