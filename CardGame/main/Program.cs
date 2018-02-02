using System;
using classes;
namespace main
{
    class Program
    {
        static void Main(string[] args)
        {
            Game spil = new Game();
            Player spiller1 = new Player("spiller1");
            Player spiller2 = new Player("spiller2");
            spil.AcceptPlayer(spiller2);
            spil.AcceptPlayer(spiller1);

            spil.DealCards(5);

            Console.WriteLine("Welcome to card game!!");

            spil.Winner();
        }
    }
}
