using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;


namespace WebDynamicMethods
{
    class MyMethods
    {
        public MyMethods() { }


        public string message(params string[] list)
        {
            string res = "<HTML><BODY> Hello";
            string text = "";
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != null)
                {
                    text += " et " + list[i];
                }

            }
            res += text.Substring(3);
            res += " </BODY></HTML>";
            return res  ;
        }
        public string addition(params string[] list)
        {
            int res = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if(list[i] != null)
                {
                    res += Int16.Parse(list[i]);
                }
                
            }
            return res.ToString();
        }

        public string multiplication(params string[] list)
        {
            int res = 0;
            if (list.Length != 0)
            {
                res = 1;
            }
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != null)
                {
                    res *= Int16.Parse(list[i]);
                }

            }
            return res.ToString();
        }



        public string messageFromExec(params string[] list)
        {
            string arguments = "";
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != null)
                {
                    arguments += list[i] + " ";
                }

            }
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"D:\user\julien\Documents\Semestre 8\web\TD2\WebDynamic\ExecMethod\bin\Debug\ExecMethod.exe";
            start.Arguments = arguments;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }
    }
}
