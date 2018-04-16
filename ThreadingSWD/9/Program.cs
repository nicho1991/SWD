using System;
using System.Threading;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            TotalCount ThisWillGoWrong = new TotalCount();
            
            Counter Counterone = new Counter();
            Counter CounterTwo = new Counter();

            Thread one = new Thread (() => Counterone.startCounting(20000,ThisWillGoWrong));
            Thread two = new Thread (() => CounterTwo.startCounting(50000,ThisWillGoWrong));

            one.Start();
            two.Start();


            System.Console.WriteLine(ThisWillGoWrong.count);
        }
    }

    class TotalCount{
        public int count {get;set;} = 0;
    }
    class Counter{
        public void startCounting(int times, TotalCount thisOne){
            for (int i = 0; i < times; i++)
            {
                thisOne.count ++;
            }
        }
    }
}
