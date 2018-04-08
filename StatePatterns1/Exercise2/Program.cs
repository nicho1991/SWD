using System;

namespace Exercise2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var flash = new Flashlight();

            while (true)
                if (Console.ReadKey().Key == ConsoleKey.A)
                    flash.Power();
        }
    }

    public class Flashlight
    {
        private FlashLightState _state = new Off();

        public void Power()
        {
            _state.HandlePower(this);
        }

        public void LightOn()
        {
            Console.WriteLine("light on");
        }

        public void LightOff()
        {
            Console.WriteLine("light off");
            SetSetate(new On());
        }

        public void SetSetate(FlashLightState state)
        {
            _state = state;
        }
    }

    public interface FlashLightState
    {
        void HandlePower(Flashlight FlashLight);
    }

    public class On : FlashLightState
    {
        public void HandlePower(Flashlight FlashLight)
        {
            FlashLight.SetSetate(new Off());
            FlashLight.LightOn();
        }
    }

    public class Off : FlashLightState
    {
        public void HandlePower(Flashlight FlashLight)
        {
            FlashLight.SetSetate(new On());
            FlashLight.LightOff();
        }
    }
}