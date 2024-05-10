using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.ViewModels.Admin.Category;
using RealEstate_Domain.ViewModels.Admin.RealEstate;

namespace RealEstate_Web.Areas.Identity.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        #region consractor

        private readonly ICategoryService _categoryService;

        public IndexModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion

        public List<CategoryAdminViewModel> Categories { get; set; }

        public async Task OnGet()
        {
            Categories = await _categoryService.GetAllCategoriesForAdmin();
        }
    }
}
