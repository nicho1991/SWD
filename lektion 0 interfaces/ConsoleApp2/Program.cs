using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");

            IDoThings mystuff = new DoStuff();
            

        }
    }

    class DoStuff : IDoThings
    {
        public void DoNothing()
        {

        }

        public int DoSomething(int number)
        {
            return 1;
        }

        public string DoSomethingElse(string input)
        {
            return "hi";
        }
    }

    class Dohickey : IDoThings
    {
        public void DoNothing()
        {
            Console.WriteLine("DoHickey::DoNothing()");
        }
        public int DoSomething(int number)
        {
            return 1;
        }
        public string DoSomethingElse(string input)
        {
            return "";
        }
    }


    interface IDoThings
    {
        void DoNothing();
        int DoSomething(int number);
        string DoSomethingElse(string input);

    }


}
