using System;
using ServiceReference1;
using ServiceReference2;
namespace SOAPWebServiceClient
{
    class Program
    {
        static void Main(string[] args){

            /*ServiceReference1.CalculatorSoap calculator = new ServiceReference1.CalculatorSoapClient(ServiceReference1.CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);
            Console.WriteLine("2*3: " + calculator.AddAsync(4, 2).Result);
            Console.ReadLine();*/
            ServiceReference2.IMathsOperations mathsOperations = new ServiceReference2.MathsOperationsClient(ServiceReference2.MathsOperationsClient.EndpointConfiguration.BasicHttpBinding_IMathsOperations);
            Console.WriteLine("4+2: " + mathsOperations.addAsync(4, 2).Result);
            Console.WriteLine("4-2: " + mathsOperations.subtractAsync(4, 2).Result);
            Console.WriteLine("4*2: " + mathsOperations.multiplyAsync(4, 2).Result);
            Console.WriteLine("4/2: " + mathsOperations.divideAsync(4, 2).Result);
            Console.ReadLine();

        }
    }
}
