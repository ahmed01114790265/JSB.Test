using JSB.Contracts.DTO;
using JSB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Contracts.InterfaceFactory
{
   public interface ICategoryFactory

    {
        Category CreateCategory(CategoryDTO categoryDTO);
        CategoryDTO CreateCategoryDTO(Category category);
        void UpdateCategory(Category category, CategoryDTO categoryDTO);
        bool ValidateBeforeDelete(Guid categoryId, Guid categoryDTOId);
    }
}
