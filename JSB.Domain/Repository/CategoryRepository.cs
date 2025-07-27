using JSB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Domain.Repository
{
    public class CategoryReposit : ICategoryRepository
    {
        JSBDbContext _context;
        public CategoryReposit(JSBDbContext context)
        {
            _context = context;
        }
        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
        }
        public async Task<Category> GetCategoryById(Guid CategoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == CategoryId);
        }
        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}
