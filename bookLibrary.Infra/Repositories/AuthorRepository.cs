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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DbSqlAdoContext _contextAdo;

        public AuthorRepository(DbSqlAdoContext context)
        {
            _contextAdo = context;
        }

        public async Task Create(Author author)
        {
            try
            {
                string query = "INSERT INTO autores(id, nome) VALUES(@id, @nome)";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", author.Id),
                    new SqlParameter("@nome", author.Name)
                };

                _contextAdo.ExecutarComando(CommandType.Text, query, parameters);
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(Author author)
        {
            try
            {
                string query = "UPDATE autores SET nome = @nome WHERE ID = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", author.Id),
                    new SqlParameter("@nome", author.Name)
                };

                _contextAdo.ExecutarComando(CommandType.Text, query, parameters);
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
                string query = "DELETE FROM autores WHERE id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };

                _contextAdo.ExecutarComando(CommandType.Text,query, parameters);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Author>> GetAll(int qtdItems, int page)
        {
            List<Author> lista = null;

            string query =  "SELECT TOP (@qtdItems) id, nome " +
                            "FROM (SELECT ROW_NUMBER() OVER(ORDER BY nome) AS linha, id, nome FROM autores WITH(NOLOCK)) as paginado " +
                            "WHERE linha > @qtdItems * (@page - 1)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@qtdItems", qtdItems),
                new SqlParameter("@page", page)
            };

            using (var result = _contextAdo.ExecutarConsulta(CommandType.Text, query, parameters))
            {
                lista = new List<Author>();

                while (result.Read())
                {
                    var author = new Author(result[1].ToString());
                    author.FillIdAuthor(result[0].ToString());

                    lista.Add(author);
                }
            }

            return lista;
        }

        public async Task<Author> GetById(Guid id)
        {
            try
            {
                Author author = null;

                string query = "SELECT id, nome FROM autores WHERE Id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };

                using (var result = _contextAdo.ExecutarConsulta(CommandType.Text, query, parameters))
                {
                    while (result.Read())
                    {
                        author = new Author(result[1].ToString());
                        author.FillIdAuthor(result[0].ToString());
                    }
                }

                return author;
            }
            catch
            {
                throw;
            }
        }
    }
}
