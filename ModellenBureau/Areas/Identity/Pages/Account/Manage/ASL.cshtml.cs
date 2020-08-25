using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ModellenBureau.Data;
using System.Web;
using System.Net;
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
            [Display(Name = "KvK Number")]
            public int KvK { get; set; }
            [Display(Name = "BTW Number")]
            public string BTW { get; set; }
            [Display(Name = "Logo")]
            public IFormFile Logo { get; set; }
        }

        private async Task LoadAsync(ASL user)
        {
            var CurrentLog = await _userManager.GetUserAsync(User);
            if (this.User.IsInRole("Customer"))
            {
                var CustomerLog = _db.Customers.FirstOrDefault(c => c.User.Id == user.Id);
                Input = new InputModel
                {
                    FirstName = CurrentLog.FirstName,
                    LastName = CurrentLog.LastName,
                    Age = CurrentLog.Age,
                    Street = CurrentLog.Street,
                    ZipCode = CurrentLog.ZipCode,
                    HouseNumber = CurrentLog.HouseNumber,
                    City = CurrentLog.City,
                    KvK = CustomerLog.KvK,
                    BTW = CustomerLog.BTW,
                    //Logo = CustomerLog.Logo
                };
            }
        }
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return RedirectToPage(new { count = files.Count, size });
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
            
            if (Input.FirstName != user.FirstName || Input.FirstName == user.FirstName)
            {
                if (this.User.IsInRole("Customer"))
                {
                    var CustomerLog = _db.Customers.FirstOrDefault(c => c.User.Id == user.Id);
                    user.FirstName = Input.FirstName;
                    user.LastName = Input.LastName;
                    user.Age = Input.Age;
                    user.Street = Input.Street;
                    user.ZipCode = Input.ZipCode;
                    user.HouseNumber = Input.HouseNumber;
                    user.City = Input.City;
                    CustomerLog.KvK = Input.KvK;
                    CustomerLog.BTW = Input.BTW;
                }



                var SetASL = await _userManager.UpdateAsync(user);
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