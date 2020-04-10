using bookLibrary.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace bookLibrary.Domain.Queries
{
    public static class BookQueries
    {
        public static Expression<Func<Book, bool>> GetBookByAuthor(Guid id)
        {
            return x => x.Author.Id == id;
        }

        public static Expression<Func<Book, bool>> GetBookByPublishingCompany(Guid id)
        {
            return x => x.PublishingCompany.Id == id;
        }

        public static Expression<Func<Book, bool>> GetBookByCategory(Guid id)
        {
            return x => x.Category.Id == id;
        }
    }
}
