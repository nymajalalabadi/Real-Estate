using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.ViewModels.Admin.RealEstate;

namespace RealEstate_Web.Pages
{
    public class AllEstatesModel : PageModel
    {
        #region consracrutor

        private readonly IRealEstatesService _realEstatesService;

        public AllEstatesModel(IRealEstatesService realEstatesService)
        {
            _realEstatesService = realEstatesService;
        }

        #endregion

        public List<RealEstateAdminViewModel> realEstates { get; set; }

        public async Task OnGet()
        {
            realEstates = await _realEstatesService.GetAllRealEstates();
        }
    }
}
