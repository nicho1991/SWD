using System;

namespace Vehicles
{
    public class Motorbike
    {
        private readonly IEngine _engine;

        public Motorbike(IEngine engine)
        {
            _engine = engine;
        }

        public void RunAtHalfSpeed()
        {
            _engine.SetThrottle(_engine.MaxThrottle / 2);
            Console.WriteLine("Throttle at " + _engine.GetThrottle());
        }
    }

    public class GasEngine : IEngine
    {
        private uint _curThrottle;

        public GasEngine(uint maxThrottle)
        {
            MaxThrottle = maxThrottle;
        }

        public uint MaxThrottle { get; }

        public void SetThrottle(uint thr)
        {
            _curThrottle = thr;
        }

        public uint GetThrottle()
        {
            return _curThrottle;
        }
    }

    public class DieselEngine : IEngine
    {
        private uint _curThrottle;

        public DieselEngine(uint maxThrottle)
        {
            MaxThrottle = maxThrottle;
        }

        public uint MaxThrottle { get; }

        public void SetThrottle(uint thr)
        {
            _curThrottle = thr;
        }

        public uint GetThrottle()
        {
            return _curThrottle;
        }
    }

    public interface IEngine
    {
        uint MaxThrottle { get; }
        void SetThrottle(uint thr);
        uint GetThrottle();
    }
}