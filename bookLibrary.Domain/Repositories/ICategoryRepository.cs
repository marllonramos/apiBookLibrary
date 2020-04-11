using bookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bookLibrary.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(Guid id);
        Task Create(Category category);
        Task Update(Category category);
        Task Delete(Guid id);
    }
}
