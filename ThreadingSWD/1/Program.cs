using System;
using System.Threading;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HelloWriter x = new HelloWriter();

            Thread a = new Thread(() => x.sayHello("james"));
            a.Start();

            Thread b = new Thread(() => x.sayHello("other james"));
            b.Start();
            
            
        }
    }

    public class HelloWriter{

        public void sayHello(string name){
            for (int i = 0; i < 1000; i++)
            {
                System.Console.WriteLine($"Hello from {name} ran: {i}");
            }
        }

    }
}
