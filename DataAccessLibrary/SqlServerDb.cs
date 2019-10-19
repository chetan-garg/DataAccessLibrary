using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Unibet.InterfaceLibrary;

namespace Unibet.DataAccessLibrary
{

    public class SqlServerDb : IDisposable, ISqlServerDb
    {
        SqlConnection _dataConnection;
        public SqlServerDb(string connectionString)
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                _dataConnection = new SqlConnection(connectionString);
            }
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            int result = 0;
            if (command == null)
            {
                throw new ArgumentException("Sql command cannot be null.", "command");
            }
            try
            {
                _dataConnection.Open();
                result = command.ExecuteNonQuery();
            }
            finally
            {
                if(_dataConnection.State == System.Data.ConnectionState.Open) 
                    _dataConnection.Close();
            }
            return result;
        }

        public DataSet ExecuteDataSet(SqlCommand command)
        {
            DataSet result = new DataSet();
            if (command == null)
            {
                throw new ArgumentException("Sql command cannot be null.", "command");
            }
            try
            {
                DataAdapter da = new SqlDataAdapter(command);
                da.Fill(result);
            }
            finally
            {
                if (_dataConnection.State == System.Data.ConnectionState.Open)
                    _dataConnection.Close();
            }
            return result;
        }

        public SqlCommand CreateStoredProcCommand(string commandText)
        {
            return CreateCommand(commandText, CommandType.StoredProcedure);
        }

        public SqlCommand CreateCommand(string commandText, CommandType cmdType)
        {
            SqlCommand cmd = _dataConnection.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = cmdType;
            return cmd;
        }

        public void AddParameter(SqlCommand cmd, string paramName, SqlDbType dbType, object value, ParameterDirection direction)
        {
            var parameter = cmd.CreateParameter();
            parameter.ParameterName = paramName;
            parameter.SqlDbType = dbType;
            parameter.Value = value ?? DBNull.Value;
            parameter.Direction = direction;
            cmd.Parameters.Add(parameter);
        }

        public void Dispose()
        {
            if (_dataConnection != null)
            {
                _dataConnection.Dispose();
                _dataConnection = null;
            }
        }
    }
}
