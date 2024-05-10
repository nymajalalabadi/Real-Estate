using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.ViewModels.Admin.Category;

namespace RealEstate_Web.Areas.Identity.Pages.Admin.Categories
{
    public class EditModel : PageModel
    {
        #region consractor

        private readonly ICategoryService _categoryService;

        public EditModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion

        [BindProperty]
        public EditCategoryViewModel EditCategory { get; set; }

        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var category = await _categoryService.GetCategoryById(Id);

            if (category == null)
            {
                return NotFound();
            }

            EditCategory = new()
            {
                Id = Id,
                Title = category.Title,
                Description = category.Description,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _categoryService.EditCategory(EditCategory);

            return RedirectToPage("./Index");
        }

    }
}
