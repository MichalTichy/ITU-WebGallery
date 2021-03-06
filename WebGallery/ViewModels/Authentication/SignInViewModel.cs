﻿using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel.Validation;
using Microsoft.AspNetCore.Identity;
using WebGallery.BL.Services;

namespace WebGallery.ViewModels.Authentication
{
    public class SignInViewModel : NonAuthenticatedMasterPage
    {

        private readonly UserService userService;

        public SignInViewModel(UserService userService)
        {
            this.userService = userService;
        }

        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }

        public async Task SignIn()
        {
            var identity = await userService.SignInAsync(UserName, Password);
            if (identity == null)
            {
                Context.ModelState.Errors.Add(new ViewModelValidationError
                {
                    ErrorMessage = "Incorrect login",
                    PropertyPath = nameof(Password)
                });
                Context.FailOnInvalidModelState();
            }
            else
            {
                await Context.GetAuthentication().SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(identity));
                Context.RedirectToRoute("Default", allowSpaRedirect: false);
            }
        }
    }
}
