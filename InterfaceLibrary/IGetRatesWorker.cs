using System;
using System.Collections.Generic;
using System.Text;

namespace Unibet.InterfaceLibrary
{
    public interface IGetRatesWorker
    {
        void RefreshRatesFromApiAsync(string apiUrl, string apiKey);
    }
}
