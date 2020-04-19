using bookLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace bookLibrary.Infra.Contexts
{
    public class DbBookContext : DbContext
    {
        public DbBookContext(DbContextOptions<DbBookContext> options)
            :base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }       
        public DbSet<PublishingCompany> PublishingCompanies { get; set; }
        public DbSet<Reader> Readers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
