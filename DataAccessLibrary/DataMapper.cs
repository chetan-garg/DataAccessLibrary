using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Unibet.DataEntities;
using Unibet.InterfaceLibrary;

namespace Unibet.DataAccessLibrary
{
    public class DataMapper : IDataMapper
    {
        public List<CurrencyRates> ConvertDBToEntity(DataSet dataEntity)
        {
            List<CurrencyRates> entities = null;
            if (dataEntity != null && dataEntity.Tables.Count > 0)
            {
                entities = new List<CurrencyRates>();

                foreach (DataRow row in dataEntity.Tables[0].Rows)
                {
                    CurrencyRates newRate = new CurrencyRates();
                    newRate.BaseCurrency = (EnumCurrencyList)Enum.Parse(typeof(EnumCurrencyList), row["BaseCurrency"].ToString());
                    newRate.TargetCurrency = (EnumCurrencyList)Enum.Parse(typeof(EnumCurrencyList), row["TargetCurrency"].ToString());
                    newRate.ConversionRate = (double)row["ConversionRate"];
                    newRate.Timestamp = (DateTime)row["Timestamp"];

                    entities.Add(newRate);
                }
            }

            return entities;
        }

        public DataTable ConvertEntityToDataTable(List<CurrencyRates> currencyRates)
        {
            return currencyRates.GetTableFromList();
        }
    }
}
