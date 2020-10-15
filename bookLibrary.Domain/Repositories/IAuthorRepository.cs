using bookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bookLibrary.Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll(int qtdItems, int page);
        Task<Author> GetById(Guid id);
        Task Create(Author author);
        Task Update(Author author);
        Task Delete(Guid id);
    }
}
