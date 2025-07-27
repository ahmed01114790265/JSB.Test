using JSB.Contracts.DTO;
using JSB.Contracts.InterfaceFactory;
using JSB.Contracts.InterfaceService;
using JSB.Contracts.ResultModel;
using JSB.Domain.Repository;
using JSB.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Application.Service
{
   public class CategoryService : ICategoryService
    {
        private readonly ICategoryFactory _categoryFactory;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryFactory categoryFactory, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryFactory = categoryFactory;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResultModel<Guid>> AddCategory(CategoryDTO categoryDTO)
        {
            var category = _categoryFactory.CreateCategory(categoryDTO);
            _categoryRepository.CreateCategory(category);
            await _unitOfWork.SaveChangesAsync();
            return new ResultModel<Guid>()
            {
                IsValid = true,
                Model = category.Id,
            };
        }
        public async Task<ResultModel<CategoryDTO>> GetCategoryById(Guid categoryId)
        {
            var category = await _categoryRepository.GetCategoryById(categoryId);
            if (category == null)
            {
                return new ResultModel<CategoryDTO>()
                {
                    IsValid = false,
                    ErrorMessage = "Category not found"
                };
            }
            var categoryDTO = _categoryFactory.CreateCategoryDTO(category);
            return new ResultModel<CategoryDTO>()
            {
                IsValid = true,
                Model = categoryDTO
            };
        }
        public async Task<ResultList<CategoryDTO>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            if (categories == null || !categories.Any())
            {
                return new ResultList<CategoryDTO>()
                {
                    IsValid = false,
                    ErrorMessage = "No categories found"
                };
            }
            var categoryDTOs = categories.Select(c => _categoryFactory.CreateCategoryDTO(c)).ToList();
            return new ResultList<CategoryDTO>()
            {
                IsValid = true,
                ModelList = categoryDTOs
            };
        }
        public async Task<ResultModel<Guid>> UpdateCategory(CategoryDTO categoryDTO)
        {
            if(!categoryDTO.Id.HasValue)
            {
                return new ResultModel<Guid>()
                {
                    IsValid = false,
                    ErrorMessage = "Invalid book ID"
                };
            }
            var category = await _categoryRepository.GetCategoryById(categoryDTO.Id.Value);
            if (category == null)
            {
                return new ResultModel<Guid>()
                {
                    IsValid = false,
                    ErrorMessage = "Category not found"
                };
            }
            _categoryFactory.UpdateCategory(category,categoryDTO);
            await _unitOfWork.SaveChangesAsync();
            return new ResultModel<Guid>()
            {
                IsValid = true,
                Model = category.Id
            };
        }
        public async Task<ResultModel<bool>> DeleteCategory(Guid categoryId)
        {
            var category = await _categoryRepository.GetCategoryById(categoryId);
            if (category == null)
            {
                return new ResultModel<bool>()
                {
                    IsValid = false,
                    ErrorMessage = "Category not found"
                };
            }
           await _categoryRepository.DeleteCategory(category);
            await _unitOfWork.SaveChangesAsync();
            return new ResultModel<bool>()
            {
                IsValid = true,
                Model = true
            };
        }
    }
}
