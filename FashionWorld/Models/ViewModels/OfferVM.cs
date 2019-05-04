using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FashionWorld.Models.ViewModels
{
    public class OfferVM
    {
        public Product Product { get; set; }
        [Display(Name ="Discount Percent %")]
        public int DiscountPercent { get; set; }
        [Display(Name ="Offer Price")]
        public decimal NewPrice { get { return (Product.Price - (Product.Price * (DiscountPercent / 100))); }  }
    }
  


}
