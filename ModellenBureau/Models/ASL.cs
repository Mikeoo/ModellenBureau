using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModellenBureau.Models
{
    public abstract class ASL
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public int HouseNumber { get; set; }
        public string City { get; set; }
    }
}
