using bookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bookLibrary.Domain.Repositories
{
    public interface IPublishingCompanyRepository
    {
        Task<IEnumerable<PublishingCompany>> GetAll();
        Task<PublishingCompany> GetById(Guid id);
        Task Create(PublishingCompany publishingCompany);
        Task Update(PublishingCompany publishingCompany);
        Task Delete(Guid id);
    }
}
