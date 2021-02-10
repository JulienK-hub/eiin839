using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Header
    {
        private NameValueCollection headers;
        public Header(NameValueCollection headers)
        {
            this.headers = headers;
        }

        internal void print()
        {
            Console.WriteLine(headers.ToString());
        }
    }
}
