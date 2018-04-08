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
                else if (Console.ReadKey().Key == ConsoleKey.B)
                    flash.Mode();
                    
        }
    }

    public class Flashlight
    {
        private FlashLightState _state = new Off();
        private On _mode = new Solids();

        public void Power()
        {
            _state.HandlePower(this);
        }

        public void Mode()
        {
           
            _mode.HandleMode(this);
        }

        public void LightOn()
        {
            Console.WriteLine("light on");
        }

        public void LightOff()
        {
            Console.WriteLine("light off");
        }

        public void SetFlashLightState(FlashLightState state)
        {
            _state = state;
        }

        public void SetModeState(On mode)
        {
            _mode = mode;
        }

        public void SolidOn()
        {
            Console.WriteLine("Solid on");
        }

        public void FlashingOn()
        {
            Console.WriteLine("flashing on");
        }
    }

    public interface FlashLightState
    {
        void HandlePower(Flashlight FlashLight);
    }

    public interface ModeState
    {

        void HandleMode(Flashlight flashlight);
    }

    public class On : FlashLightState
    {
        public void HandlePower(Flashlight FlashLight)
        {
            FlashLight.SetFlashLightState(new Off());
            FlashLight.LightOn();
        }
        public virtual void HandleMode(Flashlight flashlight) { }
    }

    public class Solids : On , ModeState
    {
        public override void HandleMode(Flashlight flashlight)
        {
            flashlight.SetModeState(new Flashing());
            flashlight.SolidOn();
        }
    }

    public class Flashing : On , ModeState
    {
        public override void HandleMode(Flashlight flashlight)
        {
            flashlight.SetModeState(new Solids());
            flashlight.FlashingOn();
        }
    }

    public class Off : FlashLightState
    {
        public void HandlePower(Flashlight FlashLight)
        {
            FlashLight.SetFlashLightState(new On());
            FlashLight.LightOff();
        }
    }
}