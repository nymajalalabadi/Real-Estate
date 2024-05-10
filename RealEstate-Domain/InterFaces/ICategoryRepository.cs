using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate_Domain.Entities.Category;
using RealEstate_Domain.ViewModels.Admin.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Domain.InterFaces
{
    public interface ICategoryRepository
    {
        Task<Category?> GetCategoryById(int id);

        List<SelectListItem> GetAllCategories();

        Task<List<CategoryAdminViewModel>> GetAllCategoriesForAdmin();

        void AddCategory(Category category);

        void UpdateCategory(Category category);

        Task SaveChanges();
    }
}
