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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbBookContext _context;
        public CategoryRepository(DbBookContext context)
        {
            _context = context;
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Entry<Category>(category).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var category = _context.Categories.AsNoTracking().FirstOrDefault(CategoryQueries.GetById(id));
            _context.Remove(category);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories
                .AsNoTracking();
        }

        public Category GetById(Guid id)
        {
            return _context.Categories
                .AsNoTracking()
                .FirstOrDefault(CategoryQueries.GetById(id));                
        }        
    }
}
