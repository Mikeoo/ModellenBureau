using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ModellenBureau.Models;


namespace ModellenBureau.Areas.Identity.Pages.Account.Manage
{
    public class ASLModel : PageModel
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ASLModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [TempData]
        public string StatusMessage { get; set; }
        public string Username { get; private set; }
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display(Name = "Age")]
            public int Age { get; set; }
            [Display(Name = "Street")]
            public string Street { get; set; }
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }
            [Display(Name = "House Number")]
            public int HouseNumber { get; set; }
            [Display(Name = "City")]
            public string City { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            Username = userName;

            Input = new InputModel
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Street = street,
                ZipCode = zipCode,
                HouseNumber = houseNumber,
                City = city
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var CustomerAsl = await _userManager.GetUserNameAsync(user);
            if (Input != Input)
            {
                var setPhoneResult = await _userManager.SetUserNameAsync (user, Input.FirstName);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error.";
                    return RedirectToPage();
                }
            }
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}