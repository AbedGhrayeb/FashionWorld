using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FashionWorld.Models
{

    public class Market
    {
        public int MarketID { get; set; }
        [Required(ErrorMessage = ("Please, Insert Market Title"))
            , Display(Name = "Market Title")]
        public string MarketName { get; set; }
        [Display(Name = "Description")]
        public string Descripshion { get; set; }
        [Required(ErrorMessage = "Please, Insert Market Owner Name"),Display(Name ="Market Owner")]
        public string MarketOwner { get; set; }
        [Required,DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please, Insert Market Address"), Display(Name = "Market Address")]
        public string MarketAddress { get; set; }
        [Display(Name = "Facebook Page Link")]
        public string FBUrl { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }




    }
}
