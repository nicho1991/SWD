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
            HelloWriter y = new HelloWriter();


            Thread a = new Thread(() => x.sayHello("james",5));
            x.sleepPeriod = 200;
            a.Start();

            Thread b = new Thread(() => y.sayHello("other james",10));
            y.sleepPeriod = 500;
            b.Start();
            
            
        }   
    }

    public class HelloWriter{
        public int sleepPeriod {get; set;} = 200;
        public void sayHello(string name, int numbers){
            for (int i = 0 ; i <= numbers; i++)
            {
                Thread.Sleep(sleepPeriod);
                System.Console.WriteLine($"Hello from {name} ran: {i}");
            }
        }
    }
}
