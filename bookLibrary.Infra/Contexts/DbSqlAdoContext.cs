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

        #region Queries para consulta de dados
        public SqlDataReader ExecutarConsulta(CommandType commandType, string commandText, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                return ExecutarConsultaDataReader(conn, commandType, commandText, parameters);
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        private SqlDataReader ExecutarConsultaDataReader(SqlConnection connection, CommandType commandType, string commandText, SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(commandText, connection);
            PrepararComando(connection, command, commandType, commandText, parameters);

            SqlDataReader dataReader = command.ExecuteReader();
            command.Parameters.Clear();

            return dataReader;
        }
        #endregion
    }
}