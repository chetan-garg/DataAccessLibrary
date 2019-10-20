using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Unibet.DataEntities;

namespace Unibet.InterfaceLibrary
{
    public interface IDataMapper
    {
        List<CurrencyRates> ConvertDBToEntity(DataSet ds);

        DataTable ConvertEntityToDataTable(List<CurrencyRates> ds);
    }
}
