using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModellenBureau.Data;
using ModellenBureau.Models;

namespace ModellenBureau.Areas.Identity.Pages.Account.Manage
{
    public class PhotosModel : PageModel
    {
        private readonly UserManager<ASL> _userManager;
        private readonly SignInManager<ASL> _signInManager;
        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _environment;

        public PhotosModel(
            UserManager<ASL> userManager,
            SignInManager<ASL> signInManager,
            ApplicationDbContext db,
            IWebHostEnvironment environment)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _environment = environment;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public InputModel Input { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }
        public class InputModel
        {
            public AppFile Logo { get; set; }
            public List<AppFile> Photos { get; set; }
        }

        private async Task LoadAsync(ASL user)
        {
            var CurrentLog = await _userManager.GetUserAsync(User);
            if (this.User.IsInRole("Customer"))
            {
                var CustomerLog = _db.Customers.Include("Logo").FirstOrDefault(c => c.User.Id == user.Id);
                Input = new InputModel
                {
                    Logo = CustomerLog.Logo
                };
            }
            if (this.User.IsInRole("Model"))
            {
                var ModelLog = _db.Models.Include("Photos").FirstOrDefault(c => c.User.Id == user.Id);
                Input = new InputModel
                {
                    Photos = ModelLog.Photos
                };
            }
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
            var file = Path.Combine(_environment.ContentRootPath, "uploads", Upload.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }

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


            if (this.User.IsInRole("Customer"))
            {
                var CustomerLog = _db.Customers.FirstOrDefault(c => c.User.Id == user.Id);
                CustomerLog.Logo = new AppFile { UploadedContentString = Upload.FileName };
            }
            if (this.User.IsInRole("Model"))
            {
                var ModelLog = _db.Models.FirstOrDefault(c => c.User.Id == user.Id);
                //ModelLog.Photos = new AppFile { UploadedContentString = Upload.FileName };
            }


            var SetASL = await _userManager.UpdateAsync(user);
            if (!SetASL.Succeeded)
            {
                return RedirectToPage();
            }


            await _signInManager.RefreshSignInAsync(user);
            return RedirectToPage();
        }
    }

}
