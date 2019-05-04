using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionWorld.Models.ViewModels
{
    public class ProductListVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Market> Markets { get; set; }
        public IEnumerable<Favorite> Favorites { get; set; }

        public string CurrentCategory { get; set; }
        public string CurrentSection { get; set; }
        public SelectList Section { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string SearchTerm { get; set; }
        public string Text { get; set; }
    }
}
