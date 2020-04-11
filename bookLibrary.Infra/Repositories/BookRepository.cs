using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Queries;
using bookLibrary.Domain.Repositories;
using bookLibrary.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookLibrary.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DbBookContext _context;

        public BookRepository(DbBookContext context)
        {
            _context = context;
        }

        public async Task Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            Book book = await GetBook(id);

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBook(Guid id)
        {
            return await _context.Books
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetBookByReader(Guid id)
        {
            return await _context.Books
                .Where(BookQueries.GetBookByReader(id))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBookByAuthor(Guid id)
        {
            return await _context.Books
                .Where(BookQueries.GetBookByAuthor(id))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBookByPublishingCompany(Guid id)
        {
            return await _context.Books
                .Where(BookQueries.GetBookByPublishingCompany(id))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBookByCategory(Guid id)
        {
            return await _context.Books
                .Where(BookQueries.GetBookByCategory(id))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Update(Book book)
        {
            _context.Entry<Book>(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
