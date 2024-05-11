using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.Entities.RealEstate;
using RealEstate_Domain.ViewModels.Admin.RealEstate;

namespace RealEstate_Web.Pages
{
    public class EstateDetailsModel : PageModel
    {
        #region consractor

        private readonly IRealEstatesService _realEstatesService;

        public EstateDetailsModel(IRealEstatesService realEstatesService)
        {
            _realEstatesService = realEstatesService;
        }

        #endregion

        public DetailRealEstateViewModel RealEstate { get; set; }

        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id <= 0)
            {
                return NotFound();
            }

            var estate = await _realEstatesService.GetRealEstateForDetail(Id);

            if (estate is null)
            {
                return NotFound();
            }

            RealEstate = estate;

            return Page();
        }
    }
}
