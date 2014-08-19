using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPush.Api.Utils.CustomException
{
    /// <summary>
    /// Should retry for encountering this exception basically.
    /// Normally it is due to:
    /// 1. Connect timed out
    /// 2. Read timed out
    /// 3. Cannot parse domain
    /// 
    /// For Push acion, if the exception is "Read timed out" you may not want to retry it.
    /// </summary>
    [Serializable]
    public class ApiConnectionException : ApplicationException
    {
        private bool _isTimeout = false;
        private int _doneRetriedTimes = 0;

        public int DoneRetriedTimes { get { return _doneRetriedTimes; } }
        public bool IsTimeout { get { return _isTimeout; } }


        public ApiConnectionException(String message) : base(message) 
        { 

        }
        public ApiConnectionException(String message, int doneRetried ) : base( message )
        {
            _doneRetriedTimes = doneRetried;
        }
    }
}
