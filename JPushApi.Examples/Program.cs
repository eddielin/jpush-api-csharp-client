using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JPush.Examples
{
    static class Program
    {

        private static TraceSource SRC = new TraceSource("JPushSource");
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            SRC.TraceInformation(DateTime.Now.ToFileTime().ToString());
            Console.WriteLine(DateTime.Now.ToFileTime().ToString());
            int a = 1 | 3 | 7;
            Console.WriteLine(a);
            Console.WriteLine(a & 1);
        
        }
    }
}
