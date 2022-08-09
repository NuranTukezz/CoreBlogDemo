using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class AppUser :IdentityUser<int>
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
       // public bool IsAcceptTheContract { get; set; }
    }
}
