using System;
using System.Collections.Generic;
using System.Linq;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Queries;
using bookLibrary.Domain.Repositories;
using bookLibrary.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace bookLibrary.Infra.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DbBookContext _context;
        public AuthorRepository(DbBookContext context)
        {
            _context = context;
        }

        public void Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Update(Author author)
        {
            _context.Entry<Author>(author).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var author = _context.Authors.AsNoTracking().FirstOrDefault(AuthorQueries.GetById(id));
            _context.Remove(author);
            _context.SaveChanges();
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors
                .AsNoTracking();
        }

        public Author GetById(Guid id)
        {
            return _context.Authors
                .AsNoTracking()
                .FirstOrDefault(AuthorQueries.GetById(id));
        }        
    }
}
