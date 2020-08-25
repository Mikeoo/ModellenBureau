using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModellenBureau.Models
{
    public class Model
    {
        public int Id { get; set; }
        public ASL User { get; set; }
        public int Length { get; set; }
        public string HairColor  { get; set; }
        public List<AppFile> Photos { get; set; }
    }
}
