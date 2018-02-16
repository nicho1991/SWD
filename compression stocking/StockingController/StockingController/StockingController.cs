using System;

namespace StockingController
{
    public class StockingController : IBtnHandler
    {
        private readonly ICompressionCtrl _comp = new AirTightening();
        public void StartCompression()
        {
            _comp.Compress();
        }

        public void StopCompression()
        {
            _comp.Decompress();
        }
    }
}