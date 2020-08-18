using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModellenBureau.Models
{
    public class Customer : ASL
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public int KvK { get; set; }
        public int BTW { get; set; }
        public string Logo { get; set; }
    }
}
