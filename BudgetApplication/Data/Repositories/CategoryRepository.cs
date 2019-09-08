using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using BudgetApplication.Interface.Repositories;
using BudgetApplication.Models;
using BudgetApplication.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace BudgetApplication.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BudgetAppContext _context;

        public CategoryRepository(BudgetAppContext context)
        {
            _context = context;
        }

        /**
         * Adding new category (C)
         */
        public Category AddNewCategory(Category category)
        {
            if (category == null) return null;

            _context.Add(category);
            _context.SaveChanges();

            return category;
        }


        /**
         * Get all categories (R)
         */
        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        /**
         * Getting all the category name (R)
         */
        public List<string> GetAllCategoryName()
        {
            List<string> categoryNames = new List<string>();

            foreach (var category in GetAllCategories())
            {
                categoryNames.Add(category.Name);
            }

            return categoryNames;
        }

        /**
         * Getting category by ID (R)
         */
        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }

        /**
         * Getting the Category by its name
         */
        public Category GetCategoryByName(string categoryName)
        {
            return _context.Categories.FirstOrDefault(x => x.Name == categoryName);
        }

        /**
         * Editing currently existing categories (U)
         */
        public void EditCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /**
         * Deleting category (D)
         */
        public void DeleteCategory(Category category)
        {
            Category existingCategory = GetCategoryById(category.CategoryId);
            if (existingCategory == null) throw new ArgumentException($"Could not find specified item by ID {existingCategory.CategoryId}");

            _context.Categories.Remove(existingCategory);
            _context.SaveChanges();
        }
    }
}
