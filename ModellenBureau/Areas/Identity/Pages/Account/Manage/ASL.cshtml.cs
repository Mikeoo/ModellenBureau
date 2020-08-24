using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ModellenBureau.Data;
using ModellenBureau.Models;


namespace ModellenBureau.Areas.Identity.Pages.Account.Manage
{
    public class ASLModel : PageModel
    {

        private readonly UserManager<ASL> _userManager;
        private readonly SignInManager<ASL> _signInManager;
        private readonly ApplicationDbContext _db;

        
        public ASLModel(
            UserManager<ASL> userManager,
            SignInManager<ASL> signInManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
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

        private async Task LoadAsync(ASL user)
        {
            var CurrentLog = await _userManager.GetUserAsync(User);

            Input = new InputModel
            {
               FirstName = CurrentLog.FirstName,
               LastName = CurrentLog.LastName,
               Age = CurrentLog.Age,
               Street = CurrentLog.Street,
               ZipCode = CurrentLog.ZipCode,
               HouseNumber = CurrentLog.HouseNumber,
               City = CurrentLog.City
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
                return NotFound($"Unable to load user'{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if (Input.FirstName != User.FirstName)
            {
                var SetASL = await _userManager.UpdateAsync(_db.Customers.Find(user).User);
                if (!SetASL.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set your ASL data.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}