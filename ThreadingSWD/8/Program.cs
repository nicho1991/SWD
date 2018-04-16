using System;
using System.Threading;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {

            HelloWriter x = new HelloWriter();
            HelloWriter y = new HelloWriter();

            Thread a = new Thread(() => x.sayHello("james",5));
            x.sleepPeriod = 200;
            a.Start();

            Thread b = new Thread(() => y.sayHello("other james",10));
            y.sleepPeriod = 500;
            b.Start();

            NeverEnding c = new NeverEnding();
            Thread d = new Thread(() => c.neverEndindStory());
            
            d.IsBackground = false;
            d.Start();
                       

            a.Join();
            b.Join();
            c.alive = false;

            Console.WriteLine("Hello World from main");
            
        }   
    }



    public class NeverEnding{
        public bool alive = true;
        public void neverEndindStory(){
            while(alive){
                    Thread.Sleep(5000);
                    System.Console.WriteLine("Never ending story");
            }
            
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
