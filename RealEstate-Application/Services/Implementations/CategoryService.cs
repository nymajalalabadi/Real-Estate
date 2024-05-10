using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.Entities.Category;
using RealEstate_Domain.InterFaces;
using RealEstate_Domain.ViewModels.Admin.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Application.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        #region consractor

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #endregion

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }

        public List<SelectListItem> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public async Task<List<CategoryAdminViewModel>> GetAllCategoriesForAdmin()
        {
            return await _categoryRepository.GetAllCategoriesForAdmin();
        }

        public async Task<CategoryAdminViewModel> GetCategoryForDetail(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryById(categoryId);

            if (category == null)
            {
                return null;
            }

            return new CategoryAdminViewModel()
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description
            };
        }

        public async Task CreateCategory(CreateCategoryViewModel category)
        {
            var newCategry = new Category()
            {
                Title = category.Title,
                Description = category.Description,
            };

            _categoryRepository.AddCategory(newCategry);
            await _categoryRepository.SaveChanges();
        }

        public async Task EditCategory(EditCategoryViewModel edit)
        {
            var category = await _categoryRepository.GetCategoryById(edit.Id);

            if (category == null)
            {
                return;
            }

            category.Title = edit.Title;
            category.Description = edit.Description;

            _categoryRepository.UpdateCategory(category);
            await _categoryRepository.SaveChanges();
        }

        public async Task DeleteCategory(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryById(categoryId);

            if (category == null)
            {
                return;
            }

            _categoryRepository.DeleteCategory(category);

            await _categoryRepository.SaveChanges();
        }

    }
}
