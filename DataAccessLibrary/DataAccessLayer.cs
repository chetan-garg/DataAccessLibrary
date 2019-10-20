using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Unibet.DataEntities;
using Unibet.InterfaceLibrary;

namespace Unibet.DataAccessLibrary
{
    public class DataAccessLayer : IDataAccessLayer
    {
        ISqlServerDb _sql;

        public DataAccessLayer(ISqlServerDb sqlServer)
        {
            _sql = sqlServer;
        }

        public bool AddExchangeRates(DataTable currencyRates)
        {
            if (currencyRates != null && currencyRates.Rows.Count > 0)
            {
                using (SqlCommand command = _sql.CreateStoredProcCommand(Constants.AddRatesSP))
                {
                    if (command == null)
                    {
                        _sql.AddParameter(command, Constants.AddSpParam, System.Data.SqlDbType.Structured, currencyRates, System.Data.ParameterDirection.Input);
                        return _sql.ExecuteNonQuery(command) == 1;
                    }
                }
            }

            return false;
        }

        public DataSet GetExchangeRate(string baseCurrency, string targetCurrency)
        {
            using (SqlCommand command = _sql.CreateStoredProcCommand(Constants.GetRatesSP))
            {
                if (command == null)
                {
                    _sql.AddParameter(command, Constants.GetSpBaseCurrParam, System.Data.SqlDbType.VarChar, baseCurrency, System.Data.ParameterDirection.Input);
                    _sql.AddParameter(command, Constants.GetSpTargetCurrParam, System.Data.SqlDbType.VarChar, baseCurrency, System.Data.ParameterDirection.Input);
                    return _sql.ExecuteDataSet(command);
                }
            }
            return null;
        }
    }
}