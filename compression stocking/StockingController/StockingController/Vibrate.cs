using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockingController
{
    public interface IVibratingInterface
    {
        void TurnOff();
        void TurnOn();
    }
    class VibratingDevice : IVibratingInterface
    {
        public void TurnOff()
        {
            throw new NotImplementedException();
        }

        public void TurnOn()
        {
            throw new NotImplementedException();
        }
    }
}
