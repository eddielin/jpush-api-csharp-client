using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JPush.Api.Utils
{
    public class  EnumDescription : Attribute
    {
        private String _text;
        public EnumDescription(string attr)
        {
            _text = attr;
        }

        public string Text { get { return _text; } }

        static string GetDesc(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                Attribute atts = memInfo[0].GetCustomAttribute(typeof(EnumDescription), false);

                if (atts != null)
                {
                    return ((EnumDescription)atts).Text;
                }
            }
            return en.ToString();
        }
    }
}
