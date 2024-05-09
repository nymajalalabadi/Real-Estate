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

        public CreateModel(IRealEstatesService realEstatesService)
        {
            _realEstatesService = realEstatesService;
        }

        #endregion

        [BindProperty]
        public CreateRealEstateViewModel ViewModel { get; set; }

        public void OnGet()
        {
            var categories = _realEstatesService.GetAllCategories();

            ViewData["Categories"] = new SelectList(categories, "Value", "Text");
        }

        public async Task<IActionResult> OnPost()
        {
            #region Validation

            if (!ModelState.IsValid || string.IsNullOrEmpty(ViewModel.SelectedCategory))
            {
                var categories = _realEstatesService.GetAllCategories();

                ViewData["Categories"] = new SelectList(categories, "Value", "Text");

                return Page();
            }

            bool check = int.TryParse(ViewModel.SelectedCategory, out int categoryId);

            if (check is false)
            {
                ModelState.AddModelError(string.Empty, "دسته بندی انتخاب شده نامعتبر است");

                var categories = _realEstatesService.GetAllCategories();

                ViewData["Categories"] = new SelectList(categories, "Value", "Text");

                return Page();
            }

            var category = await _realEstatesService.GetCategoryById(categoryId);

            if (category is null)
            {
                ModelState.AddModelError(string.Empty, "دسته بندی انتخاب شده نامعتبر است");

                var categories = _realEstatesService.GetAllCategories();

                ViewData["Categories"] = new SelectList(categories, "Value", "Text");

                return Page();
            }

            #endregion

            await _realEstatesService.CreateRealEstate(ViewModel, categoryId);
            
            return RedirectToPage("Index");

        }

    }
}
