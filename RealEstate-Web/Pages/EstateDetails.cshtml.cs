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

        private readonly IUserService _userService;

        private readonly IFavouriteService _favouriteService;

        public EstateDetailsModel(IRealEstatesService realEstatesService, IUserService userService, IFavouriteService favouriteService)
        {
            _realEstatesService = realEstatesService;
            _userService = userService;
            _favouriteService = favouriteService;
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

            ViewData["suggested"] = await _realEstatesService.GetAllSuggestedRealEstates(Id);

            RealEstate = estate;

            return Page();
        }

        #region add favourite

        public async Task<IActionResult> OnPostAddToFavourites(int Id)
        {
            if (User is null || !User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login?returnUrl=/EstateDetails?Id=" + Id);
            }

            if (Id <= 0)
            {
                return NotFound();
            }

            var estate = await _realEstatesService.GetEstateById(Id);

            if (estate is null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserByUserName(User.Identity.Name);

            var checkIfRedundant = await _favouriteService.IsExistFavourite(user.Id, Id);

            if (checkIfRedundant is null)
            {
                await _favouriteService.CreateFavourite(user.Id, Id);
            }

            return RedirectToPage("EstateDetails", new { Id });
        }

        #endregion
    }
}
