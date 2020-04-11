using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Repositories;
using bookLibrary.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace bookLibrary.Infra.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly DbBookContext _context;

        public ReaderRepository(DbBookContext context)
        {
            _context = context;
        }

        public async Task CreateReader(Reader reader)
        {
            _context.Readers.Add(reader);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReader(Guid id)
        {
            Reader reader = await GetReader(id);

            _context.Readers.Remove(reader);
            await _context.SaveChangesAsync();
        }

        public async Task<Reader> GetReader(Guid id)
        {
            return await _context.Readers
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateReader(Reader reader)
        {
            _context.Entry<Reader>(reader).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
