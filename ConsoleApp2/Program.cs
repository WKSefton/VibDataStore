using System;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Client Two");
            Task.Run(() => new Client().Run()).GetAwaiter().GetResult();
        }
    }
}
