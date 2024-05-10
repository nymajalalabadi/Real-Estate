using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.ViewModels.Admin.Category;

namespace RealEstate_Web.Areas.Identity.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        #region consractor

        private readonly ICategoryService _categoryService;

        public DeleteModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (Category.Id == null)
            {
                return NotFound();
            }

            var category = await _categoryService.GetCategoryById(Category.Id);

            if (category != null)
            {
                await _categoryService.DeleteCategory(category.Id);

                return RedirectToPage("./Index");
            }

            return Page();
        }

    }
}
