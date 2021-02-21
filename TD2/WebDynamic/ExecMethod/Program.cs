using System;

namespace ExecMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >0){
             string res = "<HTML><BODY> Hello";
            string text = "";
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] != null)
                {
                    text += " et " + args[i];
                }

            }
            res += text.Substring(3);
            res += " </BODY></HTML>";
            Console.WriteLine(res);
           
            
            }

          else{
            Console.WriteLine("Pas d'arguments");
            }
        }
    }
}
