using bookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;

namespace bookLibrary.Domain.Repositories
{
    public interface IBookRepository
    {
        Book GetBook(Guid id);
        IEnumerable<Book> GetBookByReader(Guid id);
        void Create(Book book);
        void Update(Book book);
        void Delete(Guid id);
    }
}
