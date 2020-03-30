using bookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;

namespace bookLibrary.Domain.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(Guid id);
        void Create(Category category);
        void Update(Category category);
        void Delete(Guid id);
    }
}
