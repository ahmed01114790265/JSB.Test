using JSB.Contracts.DTO;
using JSB.Contracts.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Contracts.InterfaceService
{
    public interface ICategoryService
    {
        Task<ResultModel<Guid>> AddCategory(CategoryDTO categoryDTO);
        Task<ResultModel<CategoryDTO>> GetCategoryById(Guid categoryId);
        Task<ResultList<CategoryDTO>> GetAllCategories();
        Task<ResultModel<Guid>> UpdateCategory(CategoryDTO categoryDTO);
        Task<ResultModel<bool>> DeleteCategory(Guid categoryId);
    }
}
