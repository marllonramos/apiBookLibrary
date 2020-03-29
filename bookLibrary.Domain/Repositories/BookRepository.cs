using bookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace bookLibrary.Domain.Repositories
{
    public interface BookRepository
    {
        Book GetBook(Guid id);
        Book GetBookByReader(Guid id);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Guid id);
    }
}
