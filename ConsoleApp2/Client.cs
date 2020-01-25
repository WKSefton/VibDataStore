using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Client
    {
        public async Task Run()
        {

            Task.Run(() =>
            {
                Task.Delay(TimeSpan.FromSeconds(15)).GetAwaiter().GetResult();
                set(15);
            });

            while (true)
            {
                Console.WriteLine($"Number From DLL: {get()}");


                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        [DllImport(@"C:\Users\seftonwi\source\repos\ConsoleApp1\Debug\Dll1.dll")]
        public static extern int get();

        [DllImport(@"C:\Users\seftonwi\source\repos\ConsoleApp1\Debug\Dll1.dll")]
        public static extern void set(int temp);
        //[DllImport(@"C:\Users\seftonwi\source\repos\ConsoleApp1\Debug\Dll1.dll")]
        //public static extern void listen();
    }
}
