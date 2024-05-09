using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.ViewModels.Admin.RealEstate;

namespace RealEstate_Web.Areas.Identity.Pages.Admin.RealEstates
{
    public class EditModel : PageModel
    {
        #region consractor

        private readonly IRealEstatesService _realEstatesService;

        public EditModel(IRealEstatesService realEstatesService)
        {
            _realEstatesService = realEstatesService;
        }

        #endregion

        [BindProperty]
        public EditRealEstateViewModel ViewModel { get; set; }


        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id <= 0)
            {
                return NotFound();
            }

            var estate = await _realEstatesService.GetEstateById(Id);

            if (estate is null)
            {
                return NotFound();
            }

            ViewModel = new()
            {
                Id = estate.Id,
                Title = estate.Title,
                Address = estate.Address,
                Description = estate.Description,
                Image = estate.Image,
                Metrage = estate.Metrage,
                Price = estate.Price,
                CategoryId = estate.CategoryId,
            };

            var categories = _realEstatesService.GetAllCategories();

            ViewData["Categories"] = new SelectList(categories, "Value", "Text", ViewModel.CategoryId);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            #region Validation

            if (!ModelState.IsValid || string.IsNullOrEmpty(ViewModel.SelectedCategory))
            {
                var categories = _realEstatesService.GetAllCategories();

                ViewData["Categories"] = new SelectList(categories, "Value", "Text", ViewModel.CategoryId);

                return Page();
            }

            bool check = int.TryParse(ViewModel.SelectedCategory, out int categoryId);

            if (check is false)
            {
                ModelState.AddModelError(string.Empty, "دسته بندی انتخاب شده نامعتبر است");

                var categories = _realEstatesService.GetAllCategories();

                ViewData["Categories"] = new SelectList(categories, "Value", "Text", ViewModel.CategoryId);

                return Page();
            }

            var category = await _realEstatesService.GetCategoryById(categoryId);

            if (category is null)
            {
                ModelState.AddModelError(string.Empty, "دسته بندی انتخاب شده نامعتبر است");

                var categories = _realEstatesService.GetAllCategories();

                ViewData["Categories"] = new SelectList(categories, "Value", "Text", ViewModel.CategoryId);

                return Page();
            }

            #endregion

            await _realEstatesService.EditRealEstate(ViewModel, categoryId);

            return RedirectToPage("Index");
        }

    }
}
