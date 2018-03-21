using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePatterns1
{
    class Program
    {
        static void Main(string[] args)
        {
            FlashLight flash = new FlashLight();

            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.A)
                {
                    flash.HandleEvent(FlashLight.FlashLightEvent.PowerBtnPressed);
                }
            }

        }

        public class Light
        {
            public void LightOn()
            {
                Console.WriteLine("Light On!");
            }

            public void LightOff()
            {
                Console.WriteLine("Light Off!");
            }
        }
        public class FlashLight
        {
            Light light = new Light();

            public enum FlashLightEvent { PowerBtnPressed }
            enum FlashLightState { On, Off }
            private FlashLightState _currentState;
            public FlashLight()
            {
                _currentState = FlashLightState.Off;
            }
            public void HandleEvent(FlashLightEvent evt)
            {
                switch (_currentState)
                {
                    case FlashLightState.On:
                        _currentState = FlashLightState.Off;
                        light.LightOff();
                        break;
                    case FlashLightState.Off:
                        _currentState = FlashLightState.On;
                        light.LightOn();
                        break;
                }
            }
        }

    }
}
