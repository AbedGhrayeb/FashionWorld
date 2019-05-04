using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FashionWorld.Models
{
    public class AppUser:IdentityUser
    {
        [Display(Name = "First Name")]
        [StringLength(50)]
        [PersonalData]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(50)]
        [PersonalData]
        public string LastName { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [PersonalData]
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
        public Address Address { get; set; }
        public List<Market> Markets { get; set; }
        public List<Order> Orders { get; set; }
        public List<Favorite> Favorites { get; set; }


    }
}
