using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BudgetApplication.Interface.Repositories;
using BudgetApplication.Models;
using BudgetApplication.Models.DatabaseModels;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace BudgetApplication.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly BudgetAppContext _context;

        public ItemRepository(BudgetAppContext context)
        {
            _context = context;
        }

        /**
         * Adding item to the DB (C)
         */
        public Item AddItem(Item item)
        {
            if (item == null) return null;

            _context.Add(item);
            _context.SaveChanges();

            return item;
        }

        /**
         * Get item by the id (R)
         */
        public Item GetItemById(int id)
        {
            return _context.Items.Find(id);
        }

        /**
         * Get item using the name (R)
         */
        public Item GetItemByName(string name)
        {
            return _context.Items.FirstOrDefault(i => i.Name == name);
        }

        /**
         * Get list of items using category (R)
         */
        public IEnumerable<Item> GetItemsByCategory(int categoryId)
        {
            return _context.Items.ToList().Where(x => x.CategoryId == categoryId);
        }

        /**
         * Get a list of all the items (R)
         */
        public List<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        /**
         * Get a total amount of value with the certain category id (R)
         */
        public double GetItemValueTotalByCategory(int categoryId)
        {
            double totalValue = 0;

            foreach (var item in GetItemsByCategory(categoryId))
            {
                totalValue += double.Parse(item.Price);
            }

            return totalValue;
        }

        /**
         * Getting the total spending by month (R)
         */
        public decimal TotalSpendingByMonth(int month)
        {
            // Initialize local variable 
            decimal totalSpendingByMonth = 0;

            // Find all the items that have been purchased in that month 
            IEnumerable<Item> items = _context.Items.Where(x => x.DatePurchased.Month == month);
            
            // Add them all up
            foreach (var item in items)
            {
                totalSpendingByMonth += decimal.Parse(item.Price);
            }

            return totalSpendingByMonth; 

        }

        /**
         * Gets a list of months spending (R)
         */
        public List<decimal> GetYearSpendingMonthly()
        {
            List<decimal> monthlySpending = new List<decimal>();

            for(int i = 1; i < 13; i++)
            {
                monthlySpending.Add(TotalSpendingByMonth(i));
            }

            return monthlySpending;
        }

        /**
         * Returns the month name and that month's spending (R)
         */
        public Dictionary<string, decimal> MonthlySpendingDictionary(int month)
        {
            // If month is 0 return error 
            if (month == 0)
            {
                return null;
            }

            // Gets a one-dimensional array of type Strong containing full names of months 
            string[] monthNames = DateTimeFormatInfo.CurrentInfo.MonthNames;

            // Initializes a dictionary object 
            Dictionary<string, decimal> monthlyAnalysis = new Dictionary<string, decimal>()
            {
                {monthNames[month-1], TotalSpendingByMonth(month)} 
            };

            return monthlyAnalysis;
        }


        /**
         * Edit Item (U)
         */
        public void EditItem(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /**
         * Delete item by id (D)
         */
        public void DeleteItem(Item item)
        {
            Item existingItem = GetItemById(item.ItemId);
            if (existingItem == null) throw new ArgumentException($"Could not find specified item by ID {item.ItemId}");

            _context.Items.Remove(existingItem);
            _context.SaveChanges();
        }

    }
}
