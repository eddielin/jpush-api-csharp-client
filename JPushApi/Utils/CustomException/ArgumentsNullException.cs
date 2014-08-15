using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPush.Api.Utils.CustomException
{
    [Serializable]
    public class ArgumentsNullException : ApplicationException
    {
        private bool _isTimeout = false;


        public ArgumentsNullException(String message) : base(message) 
        { 

        }
    }
}
