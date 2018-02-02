using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {
            IEngine eng1 = new GasEngine(20);
            IEngine eng2 = new DieselEngine(50);
            Motorbike m = new Motorbike(eng1);
            Motorbike m2 = new Motorbike(eng2);
            m.RunAtHalfSpeed();
            m2.RunAtHalfSpeed();
        }
    }
}
