using System;

using ServiceReference4;
namespace SOAPWebServiceClient
{
    class Program
    {
        static void Main(string[] args){

            /*ServiceReference1.CalculatorSoap calculator = new ServiceReference1.CalculatorSoapClient(ServiceReference1.CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);
            Console.WriteLine("2*3: " + calculator.AddAsync(4, 2).Result);
            Console.ReadLine();*/
            ServiceReference4.IMathsOperations mathsOperations = new ServiceReference4.MathsOperationsClient(ServiceReference4.MathsOperationsClient.EndpointConfiguration.BasicHttpBinding_IMathsOperations);
            ServiceReference4.IMathsOperations mathsOperations2 = new ServiceReference4.MathsOperationsClient(ServiceReference4.MathsOperationsClient.EndpointConfiguration.point2);
            
            Console.WriteLine("point1 4+2: " + mathsOperations.addAsync("4", "2").Result);
            Console.WriteLine("point2 4+2: " + mathsOperations2.addAsync("4", "2").Result);
            Console.WriteLine("4-2: " + mathsOperations.subtractAsync("4", "2").Result);
            Console.WriteLine("4*2: " + mathsOperations.multiplyAsync("4", "2").Result);
            Console.WriteLine("4/2: " + mathsOperations.divideAsync("4", "2").Result);
            Console.ReadLine();

        }
    }
}
