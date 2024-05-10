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
    }
}
