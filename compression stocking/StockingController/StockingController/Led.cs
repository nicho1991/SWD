using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockingController
{
    public interface ILed
    {
        void TurnOn();
        void TurnOff();
    }
    class Led : ILed
    {
        public virtual void TurnOn()
        {
            throw new NotImplementedException();
        }

        public virtual void TurnOff()
        {
            throw new NotImplementedException();
        }
    }

    class RedLed : Led
    {
        
    }

    class GreenLed : Led
    {

    }
}
