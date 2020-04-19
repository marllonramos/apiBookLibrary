using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookLibrary.Domain.Entities;
using bookLibrary.Domain.Queries;
using bookLibrary.Domain.Repositories;
using bookLibrary.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace bookLibrary.Infra.Repositories
{
    public class PublishingCompanyRepository : IPublishingCompanyRepository
    {
        private readonly DbBookContext _context;

        public PublishingCompanyRepository(DbBookContext context)
        {
            _context = context;
        }

        public async Task Create(PublishingCompany publishingCompany)
        {
            _context.PublishingCompanies.Add(publishingCompany);
            await _context.SaveChangesAsync();
        }

        public async Task Update(PublishingCompany publishingCompany)
        {
            _context.Entry<PublishingCompany>(publishingCompany).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var publishingCompany = await _context.PublishingCompanies
                .AsNoTracking()
                .FirstOrDefaultAsync(PublishingCompanyQueries.GetById(id));
            _context.Remove(publishingCompany);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PublishingCompany>> GetAll()
        {
            return await _context.PublishingCompanies
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<PublishingCompany> GetById(Guid id)
        {
            return await _context.PublishingCompanies
                .AsNoTracking()
                .FirstOrDefaultAsync(PublishingCompanyQueries.GetById(id));
        }        
    }
}
