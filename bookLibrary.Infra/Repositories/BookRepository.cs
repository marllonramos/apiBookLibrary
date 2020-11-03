using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Queries;
using bookLibrary.Domain.Repositories;
using bookLibrary.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace bookLibrary.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DbSqlAdoContext _context;

        public BookRepository(DbSqlAdoContext context)
        {
            _context = context;
        }

        public async Task Create(Book book)
        {
            try
            {
                string query = @"INSERT INTO livros(Id, Titulo, Status, Descricao, EditoraId, AutorId, CategoriaId) 
                                VALUES(@id, @titulo, @status, @descricao, @editoraId, @autorId, @categoriaId)";

                var parameter = new SqlParameter[]
                {
                    new SqlParameter("@id", book.Id),
                    new SqlParameter("@titulo", book.Title),
                    new SqlParameter("@status", book.Status),
                    new SqlParameter("@descricao", book.Description),
                    new SqlParameter("@editoraId", book.PublishingCompany.Id),
                    new SqlParameter("@autorId", book.Author.Id),
                    new SqlParameter("@categoriaId", book.Category.Id)
                };

                _context.ExecutarComando(CommandType.Text, query, parameter);
            }
            catch
            {
                throw;
            }
        }

        public Task Update(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            try
            {
                string query = @"DELETE FROM livros WHERE id = @id";

                var parameter = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };

                _context.ExecutarComando(CommandType.Text, query, parameter);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Book> GetBook(Guid id)
        {
            try
            {
                string query = @"SELECT li.id AS livroId, li.titulo, li.descricao, li.status, 
                                    edi.Id AS editoraId, edi.nome AS editoraNome, 
                                    categ.Id AS categoriaId, categ.Nome AS categoriaNome,
                                    aut.Id AS autorId, aut.Nome AS autorNome
                                FROM livros li INNER JOIN editoras edi
                                    ON li.editoraId = edi.Id
                                    INNER JOIN categorias categ
                                    ON li.categoriaId = categ.Id
                                    INNER JOIN autores aut
                                    ON li.autorId = aut.Id
                                    WHERE li.Id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };

                Book book = null;
                PublishingCompany publishingCompany = null;
                Category category = null;
                Author author = null;

                using (var result = _context.ExecutarConsulta(CommandType.Text, query, parameters))
                {
                    while (result.Read())
                    {
                        publishingCompany = new PublishingCompany(result["editoraNome"].ToString());
                        publishingCompany.FillIdPublishingCompany(result["editoraId"].ToString());

                        category = new Category(result["categoriaNome"].ToString());
                        category.FillIdCategory(result["categoriaId"].ToString());

                        author = new Author(result["autorNome"].ToString());
                        author.FillIdAuthor(result["autorId"].ToString());

                        book = new Book(result["titulo"].ToString(), result["descricao"].ToString(), publishingCompany, author, category);
                        book.FillIdBook(result[0].ToString());
                    }
                }

                return book;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Book>> GetBookByAuthor(Guid id)
        {
            try
            {
                string query = @"SELECT li.id AS livroId, li.titulo, li.descricao, li.status, 
                                    edi.Id AS editoraId, edi.nome AS editoraNome, 
                                    categ.Id AS categoriaId, categ.Nome AS categoriaNome,
                                    aut.Id AS autorId, aut.Nome AS autorNome
                                FROM livros li INNER JOIN editoras edi
                                    ON li.editoraId = edi.Id
                                    INNER JOIN categorias categ
                                    ON li.categoriaId = categ.Id
                                    INNER JOIN autores aut
                                    ON li.autorId = aut.Id
                                    WHERE aut.Id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };

                List<Book> books = null;
                Book book = null;
                PublishingCompany publishingCompany = null;
                Category category = null;
                Author author = null;

                using (var result = _context.ExecutarConsulta(CommandType.Text, query, parameters))
                {
                    books = new List<Book>();

                    while (result.Read())
                    {   
                        publishingCompany = new PublishingCompany(result["editoraNome"].ToString());
                        publishingCompany.FillIdPublishingCompany(result["editoraId"].ToString());

                        category = new Category(result["categoriaNome"].ToString());
                        category.FillIdCategory(result["categoriaId"].ToString());

                        author = new Author(result["autorNome"].ToString());
                        author.FillIdAuthor(result["autorId"].ToString());

                        book = new Book(result["titulo"].ToString(), result["descricao"].ToString(), publishingCompany, author, category);
                        book.FillIdBook(result[0].ToString());

                        books.Add(book);
                    }
                }

                return books;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Book>> GetBookByCategory(Guid id)
        {
            try
            {
                string query = @"SELECT li.id AS livroId, li.titulo, li.descricao, li.status, 
                                    edi.Id AS editoraId, edi.nome AS editoraNome, 
                                    categ.Id AS categoriaId, categ.Nome AS categoriaNome,
                                    aut.Id AS autorId, aut.Nome AS autorNome
                                FROM livros li INNER JOIN editoras edi
                                    ON li.editoraId = edi.Id
                                    INNER JOIN categorias categ
                                    ON li.categoriaId = categ.Id
                                    INNER JOIN autores aut
                                    ON li.autorId = aut.Id
                                    WHERE categ.Id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };

                List<Book> books = null;
                Book book = null;
                PublishingCompany publishingCompany = null;
                Category category = null;
                Author author = null;

                using (var result = _context.ExecutarConsulta(CommandType.Text, query, parameters))
                {
                    books = new List<Book>();

                    while (result.Read())
                    {   
                        publishingCompany = new PublishingCompany(result["editoraNome"].ToString());
                        publishingCompany.FillIdPublishingCompany(result["editoraId"].ToString());

                        category = new Category(result["categoriaNome"].ToString());
                        category.FillIdCategory(result["categoriaId"].ToString());

                        author = new Author(result["autorNome"].ToString());
                        author.FillIdAuthor(result["autorId"].ToString());

                        book = new Book(result["titulo"].ToString(), result["descricao"].ToString(), publishingCompany, author, category);
                        book.FillIdBook(result[0].ToString());

                        books.Add(book);
                    }
                }

                return books;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Book>> GetBookByPublishingCompany(Guid id)
        {
            try
            {
                string query = @"SELECT li.id AS livroId, li.titulo, li.descricao, li.status, 
                                    edi.Id AS editoraId, edi.nome AS editoraNome, 
                                    categ.Id AS categoriaId, categ.Nome AS categoriaNome,
                                    aut.Id AS autorId, aut.Nome AS autorNome
                                FROM livros li INNER JOIN editoras edi
                                    ON li.editoraId = edi.Id
                                    INNER JOIN categorias categ
                                    ON li.categoriaId = categ.Id
                                    INNER JOIN autores aut
                                    ON li.autorId = aut.Id
                                    WHERE edi.Id = @id";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };

                List<Book> books = null;
                Book book = null;
                PublishingCompany publishingCompany = null;
                Category category = null;
                Author author = null;

                using (var result = _context.ExecutarConsulta(CommandType.Text, query, parameters))
                {
                    books = new List<Book>();

                    while (result.Read())
                    {   
                        publishingCompany = new PublishingCompany(result["editoraNome"].ToString());
                        publishingCompany.FillIdPublishingCompany(result["editoraId"].ToString());

                        category = new Category(result["categoriaNome"].ToString());
                        category.FillIdCategory(result["categoriaId"].ToString());

                        author = new Author(result["autorNome"].ToString());
                        author.FillIdAuthor(result["autorId"].ToString());

                        book = new Book(result["titulo"].ToString(), result["descricao"].ToString(), publishingCompany, author, category);
                        book.FillIdBook(result[0].ToString());

                        books.Add(book);
                    }
                }

                return books;
            }
            catch
            {
                throw;
            }
        }

        // public async Task Delete(Guid id)
        // {
        //     Book book = await GetBook(id);

        //     _context.Books.Remove(book);
        //     await _context.SaveChangesAsync();
        // }

        // public async Task Update(Book book)
        // {
        //     _context.Entry<Book>(book).State = EntityState.Modified;
        //     await _context.SaveChangesAsync();
        // }
    }
}
