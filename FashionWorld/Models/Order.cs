using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FashionWorld.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [Required(ErrorMessage = "Please Enter Your Firstname")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Lastname")]

        public string LastName { get; set; }
        [BindNever]
        public bool Shipped { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Deliver to")]
        public string DeliveryName { get; set; }
        [Display(Name = "Delivery Address")]
        public Address DeliveryAddress { get; set; }
        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalPrice { get; set; }
        [Display(Name = "Time of Order")]
        public DateTime DateCreated { get; set; }
        public string Phone { get; set; }
        public bool GiftWrap { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        public AppUser AppUser { get; set; }
    }
}
