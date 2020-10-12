using System;
using System.Data;
using bookLibrary.Domain.Shared;
using Microsoft.Data.SqlClient;

namespace bookLibrary.Infra.Contexts
{
    public class DbSqlAdoContext
    {
        private string connString = Settings.ConnectionString;

        #region Comandos que tratam da persistência de dados
        public void ExecutarComando(CommandType commandType, string commandText, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                var command = new SqlCommand();
                PrepararComando(connection, command, commandType, commandText, parameters);
                command.ExecuteNonQuery();
            }
        }

        private void PrepararComando(SqlConnection connection, SqlCommand command, CommandType commandType, string commandText, SqlParameter[] parameters)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            command.Connection = connection;
            command.CommandType = commandType;
            command.CommandText = commandText;

            if (parameters != null)
                AdicionarParametros(command, parameters);
        }

        private void AdicionarParametros(SqlCommand command, SqlParameter[] parameters)
        {
            foreach (var p in parameters)
            {
                if (p.Value == null)
                    p.Value = DBNull.Value;

                command.Parameters.Add(p);
            }
        }
        #endregion
    }
}