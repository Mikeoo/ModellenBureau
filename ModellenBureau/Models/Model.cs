using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModellenBureau.Models
{
    public class Model : ASL
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public int Length { get; set; }
        public string HairColor  { get; set; }

    }
}
