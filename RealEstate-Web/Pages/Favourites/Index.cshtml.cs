using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstate_Application.Services.Implementations;
using RealEstate_Application.Services.Interfaces;
using RealEstate_DataLayer.Context;
using RealEstate_Domain.Entities.Common;
using RealEstate_Domain.ViewModels.Favourite;

namespace RealEstate_Web.Pages.Favourites
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IFavouriteService _favouriteService;

        private readonly IUserService _userService;

        public IndexModel(IFavouriteService favouriteService, IUserService userService)
        {
            _favouriteService = favouriteService;
            _userService = userService;
        }

        public List<Favourite> Favourites { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login?returnUrl=/Favourites");

            }

            var user = await _userService.GetUserByUserName(User.Identity.Name);

            Favourites = await _favouriteService.GetFavourites(user.Id);

            return Page();

        }

        public async Task<IActionResult> OnPostRemoveToFavourites(int Id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login?returnUrl=/Favourites");
            }

            if (Id <= 0)
            {
                return NotFound();
            }

            var favourite = await _favouriteService.GetFavouriteById(Id);

            if (favourite != null)
            {
                await _favouriteService.DeleteFavourite(favourite);
            }

            return RedirectToPage("Index");
        }
    }
}
