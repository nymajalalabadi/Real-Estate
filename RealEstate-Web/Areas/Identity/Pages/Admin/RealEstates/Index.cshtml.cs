using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.Entities.RealEstate;
using RealEstate_Domain.ViewModels.Admin.RealEstate;

namespace RealEstate_Web.Areas.Identity.Pages.Admin.RealEstates
{
    public class IndexModel : PageModel
    {
        #region consractor

        private readonly IRealEstatesService _realEstatesService;

        public IndexModel(IRealEstatesService realEstatesService)
        {
            _realEstatesService = realEstatesService;
        }

        #endregion

        public List<RealEstateAdminViewModel> FilterRealEstate { get; set; }

        public async Task<IActionResult> OnGet()
        {
            FilterRealEstate = await _realEstatesService.GetAllRealEstates();

            return Page();
        }
    }
}
