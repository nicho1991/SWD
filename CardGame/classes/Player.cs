using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class Player
    {
        public string Name { get; }
        public List<Card> cards = new List<Card>();

        public Player(string name)
        {
            Name = name;
        }
        public int Total()
        {
            int total = 0;
            foreach (var kort in cards)
            {
                total += kort.Color * kort.Number;
            }

            return total;
        }

        public void Receive(Card deal)
        {
            cards.Add(deal);
        }

        public void showHand()
        {
            Console.WriteLine(Name + "has the following cards: ");
            foreach (var card in cards)
            {
                Console.WriteLine("color : " + card.Color + " number: " + card.Number);
            }
        }
    }
}
