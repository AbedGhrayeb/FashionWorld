using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FashionWorld.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage =("Please, Insert Category Name"))
            ,Display(Name ="Category Name")]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
