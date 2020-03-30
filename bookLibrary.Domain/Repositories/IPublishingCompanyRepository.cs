using bookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;

namespace bookLibrary.Domain.Repositories
{
    public interface IPublishingCompanyRepository
    {
        IEnumerable<PublishingCompany> GetAll();
        PublishingCompany GetById(Guid id);
        void Create(PublishingCompany publishingCompany);
        void Update(PublishingCompany publishingCompany);
        void Delete(Guid id);
    }
}
