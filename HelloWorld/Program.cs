using System;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Delay(10);
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
