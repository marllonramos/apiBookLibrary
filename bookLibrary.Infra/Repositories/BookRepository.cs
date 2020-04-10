using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Repositories;
using bookLibrary.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bookLibrary.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DbBookContext _context;

        public BookRepository(DbBookContext context)
        {
            _context = context;
        }

        public void Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Book book = GetBook(id);

            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public Book GetBook(Guid id)
        {
            return _context.Books
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Book> GetBookByReader(Guid id)
        {
            return _context.Books
                .Where(x => x.Reader.Id == id)
                .AsNoTracking()
                .ToList();
        }

        public void Update(Book book)
        {
            _context.Entry<Book>(book).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
