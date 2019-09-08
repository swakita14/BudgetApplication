using System.Collections.Generic;
using BudgetApplication.Models;
using BudgetApplication.Models.DatabaseModels;

namespace BudgetApplication.Interface.Repositories
{
    public interface IItemRepository
    {
        Item AddItem(Item item);

        Item GetItemById(int id);

        Item GetItemByName(string name);

        IEnumerable<Item> GetItemsByCategory(Category category);

        List<Item> GetAllItems();

        void EditItem(Item item);

        void DeleteItem(Item item);
    }
}