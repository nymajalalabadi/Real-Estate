using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.ViewModels.Admin.RealEstate;

namespace RealEstate_Web.Areas.Identity.Pages.Admin.RealEstates
{
    public class DeleteModel : PageModel
    {
        #region consractor

        private readonly IRealEstatesService _realEstatesService;

        public DeleteModel(IRealEstatesService realEstatesService)
        {
            _realEstatesService = realEstatesService;
        }

        #endregion

        [BindProperty]
        public DetailRealEstateViewModel ViewModel { get; set; }

        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id <= 0)
            {
                return NotFound();
            }

            var estate = await _realEstatesService.GetEstateById(Id);

            ViewModel = new()
            {
                Id = estate.Id,
                Title = estate.Address,
                Address = estate.Address,
                Description = estate.Description,
                Image = estate.Image,
                Metrage = estate.Metrage,
                Price = estate.Price,
                CategoryTitle = estate?.Category?.Title,
            };

            if (ViewModel is null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ViewModel.Id <= 0)
            {
                return NotFound();
            }

            await _realEstatesService.DeleteRealEstate(ViewModel);

            return RedirectToPage("Index");
        }

    }
}
