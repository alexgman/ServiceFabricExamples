using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStatelessService;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using System.Threading;

namespace CalculatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                var calculatorClient = ServiceProxy.Create<ICalculatorService>
                        (new Uri($"fabric:/CalculatorService/MyStatelessService"));  //service locator
                var result = calculatorClient.Add(1, 2).Result;
                Console.WriteLine(result);
                Thread.Sleep(3000);
            }

        }
    }
}
