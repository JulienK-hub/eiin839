using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using WebDynamicMethods;
using System.Web;


namespace WebDynamic
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //if HttpListener is not supported by the Framework
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("A more recent Windows version is required to use the HttpListener class.");
                return;
            }
 
 
            // Create a listener.
            HttpListener listener = new HttpListener();

            // Add the prefixes.
            if (args.Length != 0)
            {
                foreach (string s in args)
                {
                    listener.Prefixes.Add(s);
                    // don't forget to authorize access to the TCP/IP addresses localhost:xxxx and localhost:yyyy 
                    // with netsh http add urlacl url=http://localhost:xxxx/ user="Tout le monde"
                    // and netsh http add urlacl url=http://localhost:yyyy/ user="Tout le monde"
                    // user="Tout le monde" is language dependent, use user=Everyone in english 

                }
            }
            else
            {
                Console.WriteLine("Syntax error: the call must contain at least one web server url as argument");
            }
            listener.Start();

            // get args 
            foreach (string s in args)
            {
                Console.WriteLine("Listening for connections on " + s);
            }

            // Trap Ctrl-C on console to exit 
            Console.CancelKeyPress += delegate {
                // call methods to close socket and exit
                listener.Stop();
                listener.Close();
                Environment.Exit(0);
            };


            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                string documentContents;
                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }
                
                // get url 
                Console.WriteLine($"Received request for {request.Url}");

                //get url protocol
                Console.WriteLine(request.Url.Scheme);
                //get user in url
                Console.WriteLine(request.Url.UserInfo);
                //get host in url
                Console.WriteLine(request.Url.Host);
                //get port in url
                Console.WriteLine(request.Url.Port);
                //get path in url 
                Console.WriteLine(request.Url.LocalPath);


                //Question 4:
                // Exemple1: http://localhost:8080/a/MyMethod/addition?param1=2&param2=3
                // Exemple2: http://localhost:8080/a/MyMethod/addition?param1=1&param2=5&param3=2&param4=3
                // Exmeple3: http://localhost:8080/a/MyMethod/message?param1=Julien&param2=Marie&param3=Andr%C3%A9e

                // Question 5:
                // Exemple: http://localhost:8080/a/MyMethod/message?param1=Julien&param2=Marie&param3=Andr%C3%A9e


                // parse path in url 
                foreach (string str in request.Url.Segments)
                {
                        Console.WriteLine(str);

                        Type type = typeof(WebDynamicMethods.MyMethods);
                        MethodInfo method = type.GetMethod(str);
                    WebDynamicMethods.MyMethods c = new WebDynamicMethods.MyMethods();
                        if (method != null)
                        {
                            Console.WriteLine("\nméthode appelée: " + str);
                            int nbParams = 4; //nombre de paramètres max traités dans l'URL
                            string[] array1 = new string[nbParams];
                            for (int i =1; i <= nbParams; i++)
                            { // boucle qui parse les paramètres dans une liste
                                string var = HttpUtility.ParseQueryString(request.Url.Query).Get("param" + i );
                                array1[i-1] = HttpUtility.ParseQueryString(request.Url.Query).Get("param" + i);
                            }

                        string[][] array2 = new string[][] { array1 };
                        string result = (string)method.Invoke(c, array2);
                        Console.WriteLine("résultat de la méthode : " + result + "\n");
                            
                        }
                }
                
                
                //get params un url. After ? and between &

                Console.WriteLine(request.Url.Query);

                //parse params in url
                Console.WriteLine("param1 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param1"));
                Console.WriteLine("param2 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param2"));
                Console.WriteLine("param3 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param3"));
                Console.WriteLine("param4 = " + HttpUtility.ParseQueryString(request.Url.Query).Get("param4"));

                //
                Console.WriteLine(documentContents);

                // Obtain a response object.
                HttpListenerResponse response = context.Response;

                // Construct a response.
                string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
            }
            // Httplistener neither stop ... But Ctrl-C do that ...
            // listener.Stop();
        }
    }
}