using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Repositories;
using bookLibrary.Infra.Contexts;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace bookLibrary.Infra.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbSqlAdoContext _context;

        public RoleRepository(DbSqlAdoContext context)
        {
            _context = context;
        }

        public async Task CreateRole(Role role)
        {
            try
            {
                string query = @"INSERT INTO perfis(id, nome, prioridade) 
                                    VALUES(@id, @nome, @prioridade)";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", role.Id),
                    new SqlParameter("@nome", role.Name),
                    new SqlParameter("@prioridade", role.Priority)
                };

                _context.ExecutarComando(CommandType.Text, query, parameters);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateRole(Role role)
        {
            try
            {
                string query = @"UPDATE perfis SET prioridade = @prioridade
                                    WHERE id = @id";

                var parameters = new SqlParameter[]
                {
                        new SqlParameter("@id", role.Id),
                        new SqlParameter("@prioridade",  role.Priority)
                };

                _context.ExecutarComando(CommandType.Text, query, parameters);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteRole(Guid id)
        {
            try
            {
                string query = @"DELETE FROM perfis WHERE id = @id";

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

        public async Task<Role> GetRole(Guid id)
        {
            try
            {
                string query = @"SELECT nome, prioridade
                                    FROM perfis WHERE id = @id";

                var parameters = new SqlParameter[]
                {
                        new SqlParameter("@id", id)
                };

                Role role = null;

                using (SqlDataReader dr = _context.ExecutarConsulta(CommandType.Text, query, parameters))
                {
                    while (dr.Read())
                    {
                        role = new Role(dr["nome"].ToString(),int.Parse(dr["prioridade"].ToString()));
                        role.FillRoleId(id);
                    }
                }

                return role;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Role>> GetAllRoles()
        {
            try
            {
                string query = @"SELECT id, nome, prioridade
                                    FROM perfis";

                List<Role> roles = new List<Role>();

                using (SqlDataReader dr = _context.ExecutarConsulta(CommandType.Text, query, null))
                {
                    while (dr.Read())
                    {
                        Role role = new Role(dr["nome"].ToString(), int.Parse(dr["prioridade"].ToString()));
                        role.FillRoleId(Guid.Parse(dr["id"].ToString()));

                        roles.Add(role);
                    }
                }

                return roles;
            }
            catch
            {
                throw;
            }
        }
    }
}
