using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class Player
    {
        public string Name { get; set; }
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

        public virtual void Receive(Card deal)
        {
            cards.Add(deal);
        }

        public void showHand()
        {
            Console.WriteLine(Name + " has the following cards: ");
            foreach (var card in cards)
            {
                Console.WriteLine("color : " + card.Color + " number: " + card.Number);
            }
        }
    }

    public class WeakPlayer : Player
    {
 

        public WeakPlayer(string name) : base(name)
        {
            Name = name + "weak";
        }

        public override void Receive(Card deal)
        {
            if (cards.Count > 2)
                return;
            cards.Add(deal);

        }
    }
}
