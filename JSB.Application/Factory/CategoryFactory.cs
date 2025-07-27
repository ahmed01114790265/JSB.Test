using JSB.Contracts.DTO;
using JSB.Contracts.InterfaceFactory;
using JSB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Application.Factory
{
    public class CategoryFactory : ICategoryFactory
    {
        public Category CreateCategory(CategoryDTO categoryDTO)
        {
            return new Category()
            {
                Id = Guid.NewGuid(),
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };
        }
        public CategoryDTO CreateCategoryDTO(Category category)
        {
            return new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
        public void UpdateCategory(Category category, CategoryDTO categoryDTO)
        {
            category.Name = categoryDTO.Name;
            category.Description = categoryDTO.Description;
        }
        public bool ValidateBeforeDelete(Guid categoryId, Guid categoryDTOId)
        {
            if (categoryId == categoryDTOId)
                return true;
            return false;
        }

    }
}
