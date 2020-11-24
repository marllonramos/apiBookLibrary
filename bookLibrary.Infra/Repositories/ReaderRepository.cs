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
                string query = @"INSERT INTO leitores(id, nome, email, password, idperfil) 
                                    VALUES(@id, @nome, @email, @password, @perfil)";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", reader.Id),
                    new SqlParameter("@nome", reader.Name),
                    new SqlParameter("@email", reader.Email),
                    new SqlParameter("@password", reader.Password),
                    new SqlParameter("@perfil", reader.RoleId)
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
                string query = @"UPDATE leitores SET nome = @nome, password = @password, idperfil = @perfil 
                                    WHERE id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", reader.Id),
                    new SqlParameter("@nome", reader.Name),
                    new SqlParameter("@password", reader.Password),
                    new SqlParameter("@perfil", reader.RoleId)
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
                string query = @"DELETE FROM leitores WHERE id = @id";

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
                string query = @"SELECT lei.nome, lei.email, lei.password, lei.idperfil, perf.nome nomePerfil, perf.prioridade
                                    FROM leitores lei
                                    INNER JOIN perfis perf
                                    ON lei.IdPerfil = perf.Id
                                    WHERE lei.id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };

                Reader reader = null;
                Role role = null;

                using (SqlDataReader dr = _context.ExecutarConsulta(CommandType.Text, query, parameters))
                {
                    while (dr.Read())
                    {
                        reader = new Reader(dr["nome"].ToString(), dr["email"].ToString(), dr["password"].ToString(), Guid.Parse(dr["idperfil"].ToString()));
                        reader.FillReaderId(id);

                        role = new Role(dr["nomePerfil"].ToString(), int.Parse(dr["prioridade"].ToString()));
                        role.FillRoleId(Guid.Parse(dr["idperfil"].ToString()));

                        reader.AddRole(role);
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
