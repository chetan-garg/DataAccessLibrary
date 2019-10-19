using System;
using System.Collections.Generic;
using Unibet.DataEntities;

namespace Unibet.InterfaceLibrary
{
    public interface IDataHandler
    {
        bool AddExchangeRates(List<CurrencyRates> currencyRates);
        List<CurrencyRates> GetExchangeRate(string baseCurrency, string targetCurrency);
    }
}
