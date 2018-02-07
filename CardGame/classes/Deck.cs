using System;
using System.Collections.Generic;


namespace classes
{
    class Deck
    {
        private List<Card> _cards = new List<Card>();
        public Deck()
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    _cards.Add(new Card(i,j));
                }
            }
        }


        public void Deal(int numberOfCards, Player person)
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                if (_cards.Count > 0)
                {
                    Random rand = new Random();
                    int card = rand.Next(0, _cards.Count);
                    person.Receive(_cards[card]);
                    _cards.RemoveAt(card);
                }
                else return;
            }
        }
    }
}
