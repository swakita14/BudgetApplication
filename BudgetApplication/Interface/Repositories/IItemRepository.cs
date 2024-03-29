﻿using System.Collections.Generic;
using BudgetApplication.Models;
using BudgetApplication.Models.DatabaseModels;

namespace BudgetApplication.Interface.Repositories
{
    public interface IItemRepository
    {
        Item AddItem(Item item);

        Item GetItemById(int id);

        Item GetItemByName(string name);

        IEnumerable<Item> GetItemsByCategory(int categoryId);

        List<Item> GetAllItems();

        void EditItem(Item item);

        void DeleteItem(Item item);

        decimal TotalSpendingByMonth(int month);

        double GetItemValueTotalByCategory(int categoryId);

        List<decimal> GetYearSpendingMonthly();

        Dictionary<string, decimal> MonthlySpendingDictionary(int month);

    }
}