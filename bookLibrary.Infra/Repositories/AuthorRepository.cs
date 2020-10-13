using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Queries;
using bookLibrary.Domain.Repositories;
using bookLibrary.Infra.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace bookLibrary.Infra.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        // private readonly DbBookContext _context;
        private readonly DbSqlAdoContext _contextAdo;
        // public AuthorRepository(DbBookContext context)
        // {
        //     _context = context;
        // }
        public AuthorRepository(DbSqlAdoContext context)
        {
            _contextAdo = context;
        }

        public async Task Create(Author author)
        {
            try
            {
                string query = "INSERT INTO autor(id, nome) VALUES(@id, @nome)";

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
                string query = "UPDATE autor SET nome = @nome WHERE ID = @id";

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
            // var author = await _context.Authors
            //     .AsNoTracking()
            //     .FirstOrDefaultAsync(AuthorQueries.GetById(id));
            // _context.Remove(author);
            // await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return new List<Author>();
            // return await _context.Authors
            //     .AsNoTracking()
            //     .ToListAsync();
        }

        public async Task<Author> GetById(Guid id)
        {
            try
            {
                Author author = null;

                string query = "SELECT id, nome FROM autor WHERE Id = @id";

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
