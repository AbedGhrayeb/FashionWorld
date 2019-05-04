
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionWorld.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; } = DateTime.Now.Date;
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Set Qiantity Up Zero")]
        public int Quantity { get; set; }
        public bool InStock { get {
                if (Quantity > 0)
                { return true; }
                else
                { return false; } } set { } }
       
        public string ImageUrl { get; set; }
        [Required]
        public int MarketId { get; set; }       
        public Market Market { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Type { get; set; }
        public int Discount { get; set; }
        public decimal  SalePrice { get; set; }
        public List<Favorite> Favorites { get; set; }
    }


   

}
