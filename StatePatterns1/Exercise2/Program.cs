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
        private FlashLightState _state = new Solid();

        public void Power()
        {
            _state.HandlePower(this);
        }

        public void Mode()
        {
            _state.HandleMode(this);
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
        void HandleMode(Flashlight flashlight);
    }

    public abstract class on : FlashLightState
    {
        public virtual void HandlePower(Flashlight FlashLight)
        {
            FlashLight.SetFlashLightState(new Off());
            FlashLight.LightOff();
        }

        public virtual void HandleMode(Flashlight flashlight)
        {
            // up to the inherited
        }
    }

    public class Solid : on
    {
        public override void HandleMode(Flashlight flashlight)
        {
            flashlight.SetFlashLightState(new Flashing());
            flashlight.SolidOn();
        }
    }

    public class Flashing : on
    {
        public override void HandleMode(Flashlight flashlight)
        {
            flashlight.SetFlashLightState(new Solid());
            flashlight.FlashingOn();
        }
    }

    public class Off : FlashLightState
    {
        public void HandlePower(Flashlight FlashLight)
        {
            FlashLight.SetFlashLightState(new Solid());
            FlashLight.LightOn();
        }

        public virtual void HandleMode(Flashlight flashlight)
        {
        }
    }
}