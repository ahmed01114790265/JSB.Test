using JSB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Domain.Repository
{
   public interface ICategoryRepository
    {
        void CreateCategory(Category category);
        Task<Category> GetCategoryById(Guid CategoryId);
        Task<List<Category>> GetCategories();
        Task DeleteCategory(Category category);
        Task<bool> CheckCategoryId(Guid categoryId);
    }
}
