using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModellenBureau.Models;

namespace ModellenBureau.Areas.Identity.Pages.Account.Manage
{
    public class ASLModel : PageModel
    {
        public void OnGet()
        {
        }

        [Display(Name = "First Name")]
        public string _FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string _LastName { get; set; }
        [Display(Name = "Age")]
        public int _Age { get; set; }
        [Display(Name = "Street")]
        public string _Street { get; set; }
        public string _ZipCode { get; set; }
        [Display(Name = "House Number")]
        public int _HouseNumber { get; set; }
        [Display(Name = "City")]
        public string _City { get; set; }

    }
}
