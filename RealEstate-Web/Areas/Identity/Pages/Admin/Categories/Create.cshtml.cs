using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.ViewModels.Admin.Category;

namespace RealEstate_Web.Areas.Identity.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {
        #region consractor

        private readonly ICategoryService _categoryService;

        public CreateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion

        [BindProperty]
        public CreateCategoryViewModel create { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _categoryService.CreateCategory(create);

            return RedirectToPage("./Index");
        }

    }
}
