using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.ViewModels.Admin.Category;

namespace RealEstate_Web.Areas.Identity.Pages.Admin.Categories
{
    public class DetailModel : PageModel
    {
        #region consractor

        private readonly ICategoryService _categoryService;

        public DetailModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion

        public CategoryAdminViewModel Category { get; set; }

        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            Category = await _categoryService.GetCategoryForDetail(Id);

            if (Category == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
