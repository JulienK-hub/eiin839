using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace programme1
{
    class Program
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Console.WriteLine(args[0]);
            var objResponse1 = JsonSerializer.Deserialize<List<Contrat>>(args[0]);
                Console.WriteLine(objResponse1);
                int count = 0;
                foreach (Contrat element in objResponse1)
                {
                    Console.WriteLine($"Contrat #{count}: {element.name}");
                    count++;
                }
        }
    }
    public class Contrat
    {
        public int number { get; set; }
        public string contractName { get; set; }

        public string name { get; set; }
    }
}
