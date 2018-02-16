using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockingController
{
    public interface IBtnHandler
    {
        void StartCompression();
        void StopCompression();
    }
}
