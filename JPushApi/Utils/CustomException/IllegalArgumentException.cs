using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPush.Api.Utils.CustomException
{
    [Serializable]
    public class IllegalArgumentException : ApplicationException
    {
        public IllegalArgumentException(String message)
            : base(message) 
        { 

        }
    }
}
