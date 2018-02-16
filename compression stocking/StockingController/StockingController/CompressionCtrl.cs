using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockingController
{
    public interface ICompressionCtrl
    {
        void Compress();
        void Decompress();
    }

    public class CompCtrl
    {
        protected ILed _redLed = new RedLed();
        protected ILed _greenLed = new GreenLed();
        protected IVibratingInterface _vibrater = new VibratingDevice();
    }

    public class AirTightening : CompCtrl,ICompressionCtrl
    {
        protected bool CompressReady = true; //stocking is ready for compress at first
        public void Compress()
        {
            if (CompressReady) //stocking is uncompressed
            {
                _greenLed.TurnOn();
                _vibrater.TurnOn();
                //sleep
                CompressReady = false;
            }
            _greenLed.TurnOff();
            _vibrater.TurnOff();
        }

        public void Decompress()
        {
            if (!CompressReady) //stocking is compressed
            {
                _redLed.TurnOn();
                _vibrater.TurnOn();
                //sleep
                CompressReady = true;
            }
            _redLed.TurnOff();
            _vibrater.TurnOff();
        }
    }

    public class laceTightening :CompCtrl,ICompressionCtrl
    {
        protected int Clicks = 0; //loose compression
        public void Compress()
        {
                _greenLed.TurnOn();
                _vibrater.TurnOn();
                while (Clicks != 40)
                {
                    Clicks++;
                    //sleep 100ms
                }
            _greenLed.TurnOff();
            _vibrater.TurnOff();
        }

        public void Decompress()
        {
                _redLed.TurnOn();
                _vibrater.TurnOn();
                while (Clicks != 0)
                {
                    Clicks--;
                    //sleep 100ms
                }
            _redLed.TurnOff();
            _vibrater.TurnOff();
        }
    }
}
