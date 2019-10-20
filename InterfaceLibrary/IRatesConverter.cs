using System;
using System.Collections.Generic;
using System.Text;
using Unibet.DataEntities;

namespace Unibet.InterfaceLibrary
{
    public interface IRatesConverter
    {
        List<CurrencyRates> GetRatesFromJson(Rootobject jsonResponse);
    }
}
