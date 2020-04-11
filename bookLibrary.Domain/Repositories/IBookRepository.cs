using bookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bookLibrary.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetBook(Guid id);
        Task<IEnumerable<Book>> GetBookByReader(Guid id);
        Task<IEnumerable<Book>> GetBookByAuthor(Guid id);
        Task<IEnumerable<Book>> GetBookByPublishingCompany(Guid id);
        Task<IEnumerable<Book>> GetBookByCategory(Guid id);
        Task Create(Book book);
        Task Update(Book book);
        Task Delete(Guid id);
    }
}
