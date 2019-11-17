using System;
using System.Collections.Generic;
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
            decimal totalSpendingByMonth = 0;
            IEnumerable<Item> items = _context.Items.Where(x => x.DatePurchased.Month == month);
            
            foreach (var item in items)
            {
                totalSpendingByMonth += decimal.Parse(item.Price);
            }

            return totalSpendingByMonth; 

        }

        public List<decimal> GetYearSpendingMonthly()
        {
            List<decimal> yearSpendingList = new List<decimal>();

            for (int i = 1; i < 13; i++)
            {
                yearSpendingList.Add(TotalSpendingByMonth(i));
            }

            return yearSpendingList;
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
