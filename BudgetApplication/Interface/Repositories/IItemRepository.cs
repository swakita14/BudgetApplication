﻿using System.Collections.Generic;
using BudgetApplication.Models;

namespace BudgetApplication.Interface.Repositories
{
    public interface IItemRepository
    {
        Item AddItem(Item item);

        Item GetItemByName(string name);

        IEnumerable<Item> GetItemsByCategory(Category category);

        List<Item> GetAllItems();

        void EditItem(Item item);

        void DeleteItem(Item item);
    }
}