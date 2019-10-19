﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace Unibet.DataEntities
{
    public static class Constants
    {
        public const string AddRatesSP = "sp_AddRates";
        public const string GetRatesSP = "sp_GetLatestRate";

        public const string AddSpParam = "@fxRates";

        public const string GetSpBaseCurrParam = "@baseCurrency";
        public const string GetSpTargetCurrParam = "@targetCurrency";


        public static DataTable GetTableFromList<T>(this IList<T> listOfObjects)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                Type nullType = Nullable.GetUnderlyingType(prop.PropertyType);
                if (nullType != null)
                {
                    table.Columns.Add(prop.Name, nullType);
                }
                else
                {
                    table.Columns.Add(prop.Name, prop.PropertyType);
                }
            }
            object[] values = new object[table.Columns.Count];
            foreach (T item in listOfObjects)
            {
                foreach (DataColumn column in table.Columns)
                {
                    values[table.Columns.IndexOf(column)] = props[column.ColumnName].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;

        }
    }
}
