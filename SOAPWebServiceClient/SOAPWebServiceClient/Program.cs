using System;
using ServiceReference1;
namespace SOAPWebServiceClient
{
    class Program
    {
        static void Main(string[] args){

            ServiceReference1.CalculatorSoap calculator = new ServiceReference1.CalculatorSoapClient(ServiceReference1.CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);
            Console.WriteLine("2*3: " + calculator.AddAsync(4, 2).Result);
            Console.ReadLine();
        }
    }
}
