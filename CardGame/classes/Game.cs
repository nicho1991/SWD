using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class Game
    {
        
        private List<Player> Players = new List<Player>();
        private Deck _theDeck;

        public Game()
        {
            //Opret Deck
            _theDeck = new Deck();

        }
        public void AcceptPlayer(Player name)
        {
            Players.Add(name);
        }

        public void DealCards(int numberOfCards)
        {
            foreach (var person in Players)
            {
                _theDeck.Deal(numberOfCards, person);
            }
        }

        public void Winner()
        {
            var highScore = 0;
            Player winner = null;
            foreach (var person in Players)
            {
                person.showHand();
                if (person.Total() > highScore)
                    winner = person;
                highScore = person.Total();
            }

            Console.WriteLine("winner is: " + winner.Name);
            Players.Clear();

        }
    }


}
