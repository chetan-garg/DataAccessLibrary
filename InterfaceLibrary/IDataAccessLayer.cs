using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Unibet.InterfaceLibrary
{
    public interface IDataAccessLayer
    {
        bool AddExchangeRates(DataTable currencyRates);
        DataSet GetExchangeRate(string baseCurrency, string targetCurrency);
    }
}
