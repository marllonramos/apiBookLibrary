using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Repositories;
using bookLibrary.Infra.Contexts;
using Microsoft.Data.SqlClient;

namespace bookLibrary.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbSqlAdoContext _context;

        public CategoryRepository(DbSqlAdoContext context)
        {
            _context = context;
        }

        public async Task Create(Category category)
        {
            try
            {
                var query = "INSERT INTO categorias(id, nome) VALUES(@id, @nome)";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", category.Id),
                    new SqlParameter("@nome", category.Name)
                };

                _context.ExecutarComando(CommandType.Text, query, parameters);
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(Category category)
        {
            try
            {
                var query = "UPDATE categorias SET nome = @nome WHERE id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", category.Id),
                    new SqlParameter("@nome",category.Name)
                };

                _context.ExecutarComando(CommandType.Text, query, parameters);
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var query = "DELETE FROM categorias WHERE id = @id";

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

        public async Task<IEnumerable<Category>> GetAll(int qtdItems, int page)
        {
            try
            {
                List<Category> lista = null;

                var query = "SELECT TOP (@qtdItems) id, nome " +
                            "FROM (SELECT ROW_NUMBER() OVER(ORDER BY nome) AS linha, id, nome FROM categorias WITH(NOLOCK)) as paginado " +
                            "WHERE linha > @qtdItems * (@page - 1)";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@qtdItems", qtdItems),
                    new SqlParameter("@page", page)
                };

                using (var result = _context.ExecutarConsulta(CommandType.Text, query, parameters))
                {
                    lista = new List<Category>();

                    while(result.Read())
                    {
                        var category = new Category(result[1].ToString());
                        category.FillIdCategory(result[0].ToString());

                        lista.Add(category);
                    }
                }

                return lista;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Category> GetById(Guid id)
        {
            try
            {
                Category category = null;

                var query = "SELECT id, nome FROM categorias WHERE id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };

                using (var result = _context.ExecutarConsulta(CommandType.Text, query, parameters))
                {
                    while (result.Read())
                    {
                        category = new Category(result[1].ToString());
                        category.FillIdCategory(result[0].ToString());
                    }
                }

                return category;
            }
            catch
            {
                throw;
            }
        }
    }
}
