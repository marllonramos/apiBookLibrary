using bookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;

namespace bookLibrary.Domain.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
        Author GetById(Guid id);
        void Create(Author author);
        void Update(Author author);
        void Delete(Guid id);
    }
}
