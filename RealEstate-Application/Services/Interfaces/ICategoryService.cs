using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate_Domain.Entities.Category;
using RealEstate_Domain.ViewModels.Admin.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category?> GetCategoryById(int id);

        List<SelectListItem> GetAllCategories();

        Task<List<CategoryAdminViewModel>> GetAllCategoriesForAdmin();
    }
}
