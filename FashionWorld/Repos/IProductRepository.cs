using FashionWorld.Data;
using FashionWorld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionWorld.Repos
{
    public interface IProductRepository
    {
 
            IEnumerable<Product> Products { get; }

            Product GetProduct(int key);

            void AddProduct(Product product);

            void UpdateProduct(Product product);
        IEnumerable<Product> SearchProducts(string search);
  
            void Delete(Product product);
        }
        public class ProductRepository : IProductRepository
    {
            private ApplicationDbContext context;

            public ProductRepository(ApplicationDbContext ctx) => context = ctx;

            public IEnumerable<Product> Products => context.Products
                .Include(m=>m.Market).Include(c=>c.Category).ToArray();

        public Product GetProduct(int key) => context.Products
            .Include(m=>m.Market)
            .First(p => p.ProductID == key);
                

            public void AddProduct(Product product)
            {
                context.Products.Add(product);
                context.SaveChanges();
            }

            public void UpdateProduct(Product product)
            {
                Product p = context.Products.Find(product.ProductID);
            p.ProductID = product.ProductID;
            p.Name = product.Name;
            p.DateAdded = product.DateAdded;
            p.Description = product.Description;
         
            p.InStock = product.InStock;
            p.Price = product.Price;
            p.Quantity = product.Quantity;
          
                context.SaveChanges();
            }

        

            public void Delete(Product product)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }

        public IEnumerable<Product> SearchProducts(string search)
        {
            decimal price = 0;
            bool success = decimal.TryParse(search, out price);
            if (!success) price = 0;
            return context.Products.Where(p =>
                      p.Name.Contains(search) ||
                      p.Category.CategoryName.Contains(search) ||
                      p.Description.Contains(search) ||
                      p.Type.Contains(search) ||
                      p.Market.MarketName.Contains(search)||
                      p.Price==price
                    ).Include(p=>p.Market).Include(p=>p.Category).ToList();
        }
    }
    }

