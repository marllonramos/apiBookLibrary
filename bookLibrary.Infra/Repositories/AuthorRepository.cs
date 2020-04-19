using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task Create(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Author author)
        {
            _context.Entry<Author>(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var author = await _context.Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(AuthorQueries.GetById(id));
            _context.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _context.Authors
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Author> GetById(Guid id)
        {
            return await _context.Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(AuthorQueries.GetById(id));
        }        
    }
}
