using System.Collections.Generic;
using BudgetApplication.Models;
using BudgetApplication.Models.DatabaseModels;

namespace BudgetApplication.Interface.Repositories
{
    public interface ICategoryRepository
    {
        Category AddNewCategory(Category category);

        List<Category> GetAllCategories();

        List<string> GetAllCategoryName();

        Category GetCategoryById(int categoryId);

        Category GetCategoryByName(string categoryName);

        void EditCategory(Category category);

        void DeleteCategory(Category category);

    }
}