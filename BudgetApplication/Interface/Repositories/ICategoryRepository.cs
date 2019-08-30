using System.Collections.Generic;
using BudgetApplication.Models;

namespace BudgetApplication.Interface.Repositories
{
    public interface ICategoryRepository
    {
        Category AddNewCategory(Category category);

        List<Category> GetAllCategories();

        Category GetCategoryById(int categoryId);

        void EditCategory(Category category);

        void DeleteCategory(Category category);

    }
}