using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class Card
    {
        public int Color { get; }
        public int Number { get; }
            
        public Card(int i, int j)
        {
            Color = i;
            Number = j;
        }
    }

}
