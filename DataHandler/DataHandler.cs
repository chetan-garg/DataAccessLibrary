using System;
using System.Collections.Generic;
using Unibet.DataEntities;
using Unibet.InterfaceLibrary;

namespace Unibet.DataHandler
{
    public class DataHandler : IDataHandler
    {
        IDataMapper _dataMapper = null;
        IDataAccessLayer _dataLayer = null;
        public DataHandler(IDataMapper dataMapper, IDataAccessLayer dataAccess)
        {
            _dataLayer = dataAccess;
            _dataMapper = dataMapper;
        }
        public bool AddExchangeRates(List<CurrencyRates> currencyRates)
        {
            if (_dataLayer != null)
            {
                return _dataLayer.AddExchangeRates(_dataMapper.ConvertEntityToDataTable(currencyRates));
            }

            return false;
        }

        public List<CurrencyRates> GetExchangeRate(string baseCurrency, string targetCurrency)
        {
            return _dataMapper.ConvertDBToEntity(_dataLayer.GetExchangeRate(baseCurrency, targetCurrency));
        }
    }
}
