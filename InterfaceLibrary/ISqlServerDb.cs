using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Unibet.InterfaceLibrary
{
    public interface ISqlServerDb
    {        
        int ExecuteNonQuery(SqlCommand command);

        DataSet ExecuteDataSet(SqlCommand command);

        SqlCommand CreateStoredProcCommand(string commandText);

        SqlCommand CreateCommand(string commandText, CommandType cmdType);
        void AddParameter(SqlCommand cmd, string paramName, SqlDbType dbType, object value, ParameterDirection direction);

    }
}
