using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.ViewModels.Admin.RealEstate;

namespace RealEstate_Web.Pages
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

        public List<RealEstateAdminViewModel> RealEstate { get; set; }

        public async Task<IActionResult> OnGet()
        {
            RealEstate = await _realEstatesService.GetAllRealEstates();

            return Page();
        }
    }
}