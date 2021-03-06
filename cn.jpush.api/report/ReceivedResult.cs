﻿using cn.jpush.api.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cn.jpush.api.report
{
    public class ReceivedResult : BaseResult
    {

        private List<Received> receivedList = new List<Received>();

        public List<Received> ReceivedList
        {
            get { return receivedList; }
            set { receivedList = value; }
        }
	
	    public class Received {
	        public long msg_id;
	        public String android_received;
	        public String ios_apns_sent;
	    }

        public override bool isResultOK()
        {
            if (Equals(ResponseResult, HttpStatusCode.OK))
            {
                return true;
            }
            return false;
        }

        

        public override int getErrorCode()
        {
            if (null != ResponseResult)
            {
                return ResponseResult.error.errcode;
            }
            return 0;
        }

        public override string getErrorMessage()
        {
            if (null != ResponseResult)
            {
                return ResponseResult.error.errmsg;
            }
            return "";
        }
    }
}
