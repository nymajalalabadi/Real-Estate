// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RealEstate_Application.Services.Interfaces;
using RealEstate_Domain.Entities.Account;
using RealEstate_Domain.Entities.Role;
using RealEstate_Domain.ViewModels.Account;

namespace RealEstate_Web.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<UserModel> _signInManager;
        private readonly UserManager<UserModel> _userManager;
        private readonly IUserStore<UserModel> _userStore;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;

        public RegisterModel(
            UserManager<UserModel> userManager,
            IUserStore<UserModel> userStore,
            SignInManager<UserModel> signInManager,
            RoleManager<IdentityRole> roleManager,
            IUserService userService)
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userService = userService;
        }

        [BindProperty]
        public RegisterViewModel Register { get; set; }


        public async Task OnGetAsync(string returnUrl = null)
        {
            Register = new RegisterViewModel()
            {
                ReturnUrl = returnUrl
            };
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Register.PhoneNumber, CancellationToken.None);

                user.PhoneNumber = Register.PhoneNumber;

                user.FullName = Register.FullName;


                var result = await _userManager.CreateAsync(user, Register.Password);

                if (result.Succeeded)
                {
                    #region Roles

                    if (!await _roleManager.RoleExistsAsync(Roles.Admin))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));
                    }

                    if (!await _roleManager.RoleExistsAsync(Roles.User))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Roles.User));
                    }

                    var users = await _userService.GetUserForRole();

                    if (users.Count == 1)
                    {
                        await _userManager.AddToRoleAsync(user, Roles.Admin);
                    }

                    else
                    {
                        await _userManager.AddToRoleAsync(user, Roles.User);
                    }

                    #endregion

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

        private UserModel CreateUser()
        {
            try
            {
                return Activator.CreateInstance<UserModel>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(UserModel)}'. " +
                    $"Ensure that '{nameof(UserModel)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

    }
}
