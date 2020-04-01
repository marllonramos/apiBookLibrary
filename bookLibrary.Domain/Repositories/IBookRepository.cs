using bookLibrary.Domain.Entities;
using System;

namespace bookLibrary.Domain.Repositories
{
    public interface IBookRepository
    {
        Book GetBook(Guid id);
        Book GetBookByReader(Guid id);
        void Create(Book book);
        void Update(Book book);
        void Delete(Guid id);
    }
}
