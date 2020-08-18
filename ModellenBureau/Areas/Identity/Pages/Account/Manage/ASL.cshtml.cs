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
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        [Display(Name = "House Number")]
        public int HouseNumber { get; set; }
        public string City { get; set; }

    }
}
