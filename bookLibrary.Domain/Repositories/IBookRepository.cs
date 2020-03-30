using bookLibrary.Domain.Entities;
using System;

namespace bookLibrary.Domain.Repositories
{
    public interface IBookRepository
    {
        Book GetBook(Guid id);
        Book GetBookByReader(Guid id);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Guid id);
    }
}
