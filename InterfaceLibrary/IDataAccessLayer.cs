using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Unibet.DataEntities;

namespace Unibet.InterfaceLibrary
{
    public interface IDataAccessLayer
    {
        bool AddExchangeRates(List<CurrencyRates> currencyRates);
        DataSet GetExchangeRate(string baseCurrency, string targetCurrency);
    }
}
