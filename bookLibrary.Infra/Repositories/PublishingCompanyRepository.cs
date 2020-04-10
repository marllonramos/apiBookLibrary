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
    public class PublishingCompanyRepository : IPublishingCompanyRepository
    {
        private readonly DbBookContext _context;

        public PublishingCompanyRepository(DbBookContext context)
        {
            _context = context;
        }

        public void Create(PublishingCompany publishingCompany)
        {
            _context.PublishingCompanies.Add(publishingCompany);
            _context.SaveChanges();
        }

        public void Update(PublishingCompany publishingCompany)
        {
            _context.Entry<PublishingCompany>(publishingCompany).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var publishingCompany = _context.PublishingCompanies
                .AsNoTracking()
                .FirstOrDefault(PublishingCompanyQueries.GetById(id));
            _context.Remove(publishingCompany);
        }

        public IEnumerable<PublishingCompany> GetAll()
        {
            return _context.PublishingCompanies
                .AsNoTracking();
        }

        public PublishingCompany GetById(Guid id)
        {
            return _context.PublishingCompanies
                .AsNoTracking()
                .FirstOrDefault(PublishingCompanyQueries.GetById(id));
        }        
    }
}
