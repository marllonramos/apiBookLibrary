using bookLibrary.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace bookLibrary.Domain.Queries
{
    public static class PublishingCompanyQueries
    {
        public static Expression<Func<PublishingCompany, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
