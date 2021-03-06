﻿using FashionWorld.Data;
using FashionWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionWorld.Repos
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
        public class CategoryRepository : ICategoryRepository
        {
        private ApplicationDbContext context;
        public CategoryRepository(ApplicationDbContext ctx) => context = ctx;

        public IEnumerable<Category> Categories => context.Categories;

            public void AddCategory(Category category)
            {
            context.Categories.Add(category);
            context.SaveChanges();
            }

            public void DeleteCategory(Category category)
            {
            context.Categories.Remove(category);
            context.SaveChanges();
        }

            public void UpdateCategory(Category category)
            {
            context.Categories.Update(category);
            context.SaveChanges();
        }
        }
    }

