using Microsoft.AspNetCore.Mvc;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.ViewModels.Account;

namespace RealEstate_Web.ViewComponents
{
    public class HeaderComponent : ViewComponent
    {
        #region consractore

        private readonly IUserService _userService;

        public HeaderComponent(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userService.GetUserByUserName(User.Identity.Name);

                HeaderViewModel model = new()
                {
                    FullName = user.FullName
                };

                return View("/Pages/Shared/ViewComponents/_HeaderViewComponent.cshtml", model);

            }
            return View("/Pages/Shared/ViewComponents/_HeaderViewComponent.cshtml", new HeaderViewModel());
        }
    }

}
