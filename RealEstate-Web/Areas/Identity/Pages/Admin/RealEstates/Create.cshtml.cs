using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.ViewModels.Admin.RealEstate;

namespace RealEstate_Web.Areas.Identity.Pages.Admin.RealEstates
{
    public class CreateModel : PageModel
    {
        #region consractor

        private readonly IRealEstatesService _realEstatesService;

        private readonly ICategoryService _categoryService;

        public CreateModel(IRealEstatesService realEstatesService, ICategoryService categoryService)
        {
            _realEstatesService = realEstatesService;
            _categoryService = categoryService;
        }

        #endregion

        [BindProperty]
        public CreateRealEstateViewModel ViewModel { get; set; }

        public void OnGet()
        {
            var categories = _categoryService.GetAllCategories();

            ViewData["Categories"] = new SelectList(categories, "Value", "Text");
        }

        public async Task<IActionResult> OnPost()
        {
            #region Validation

            if (!ModelState.IsValid || string.IsNullOrEmpty(ViewModel.SelectedCategory))
            {
                var categories = _categoryService.GetAllCategories();

                ViewData["Categories"] = new SelectList(categories, "Value", "Text");

                return Page();
            }

            bool check = int.TryParse(ViewModel.SelectedCategory, out int categoryId);

            if (check is false)
            {
                ModelState.AddModelError(string.Empty, "دسته بندی انتخاب شده نامعتبر است");

                var categories = _categoryService.GetAllCategories();

                ViewData["Categories"] = new SelectList(categories, "Value", "Text");

                return Page();
            }

            var category = await _categoryService.GetCategoryById(categoryId);

            if (category is null)
            {
                ModelState.AddModelError(string.Empty, "دسته بندی انتخاب شده نامعتبر است");

                var categories = _categoryService.GetAllCategories();

                ViewData["Categories"] = new SelectList(categories, "Value", "Text");

                return Page();
            }

            #endregion

            await _realEstatesService.CreateRealEstate(ViewModel, categoryId);
            
            return RedirectToPage("Index");

        }

    }
}
