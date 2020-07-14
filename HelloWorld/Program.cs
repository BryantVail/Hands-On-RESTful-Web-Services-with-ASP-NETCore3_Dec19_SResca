using System;
using System.Threading.Tasks;

namespace HelloWorld
{
    
    class Program{
        static async Task Main(string [] args){
            await Task.Delay(1000);
            Console.WriteLine("Hello World");
        }
    }
}
