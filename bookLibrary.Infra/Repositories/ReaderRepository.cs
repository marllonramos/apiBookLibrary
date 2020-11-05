using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Repositories;
using bookLibrary.Infra.Contexts;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace bookLibrary.Infra.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly DbSqlAdoContext _context;

        public ReaderRepository(DbSqlAdoContext context)
        {
            _context = context;
        }

        public async Task CreateReader(Reader reader)
        {
            try
            {
                string query = @"INSERT INTO leitor(id, nome, email, password) 
                                    VALUES(@id, @nome, @email, @password)";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", reader.Id),
                    new SqlParameter("@nome", reader.Name),
                    new SqlParameter("@email", reader.Email),
                    new SqlParameter("@password", reader.Password)
                };

                _context.ExecutarComando(CommandType.Text, query, parameters);                
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateReader(Reader reader)
        {
            try
            {
                string query = @"UPDATE leitor SET nome = @nome, password = @password
                                    WHERE id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", reader.Id),
                    new SqlParameter("@nome", reader.Name),
                    new SqlParameter("@password", reader.Password)
                };

                _context.ExecutarComando(CommandType.Text, query, parameters);                
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteReader(Guid id)
        {
            try
            {
                string query = @"DELETE FROM leitor WHERE id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };

                _context.ExecutarComando(CommandType.Text, query, parameters);                
            }
            catch
            {
                throw;
            }
        }

        public async Task<Reader> GetReader(Guid id)
        {
            try
            {
                string query = @"SELECT nome, email, password 
                                    FROM leitor WHERE id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };

                Reader reader = null;

                using (SqlDataReader dr = _context.ExecutarConsulta(CommandType.Text, query, parameters))
                {
                    while (dr.Read())
                    {
                        reader = new Reader(dr["nome"].ToString(), dr["email"].ToString(), dr["password"].ToString());
                        reader.FillReaderId(id);
                    }
                }

                return reader;                
            }
            catch
            {
                throw;
            }
        }
    }
}
