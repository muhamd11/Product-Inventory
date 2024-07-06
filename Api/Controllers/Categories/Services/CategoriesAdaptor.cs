using App.Shared.Models.AdditionsModules.CategoryModule;
using App.Shared.Models.AdditionsModules.CategoryModule.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.Categories.Services
{
    public static class CategoriesAdaptor
    {
        public static Expression<Func<Category, CategoryInfo>> SelectExpressionCategoryInfo()
        {
            return category => new CategoryInfo
            {
                categoryId = category.categoryId,
                categoryName = category.categoryName,
            };
        }

        public static Expression<Func<Category, CategoryInfoDetails>> SelectExpressionCategoryDetails()
        {
            return category => new CategoryInfoDetails
            {
                categoryId = category.categoryId,
                categoryName = category.categoryName,
                categoryDescription = category.categoryDescription,
            };
        }

        public static Expression<Func<Category, CategoryInfo>> SelectExpressionCategoryInfo(this Category category)
        {
            return category => new CategoryInfo
            {
                categoryId = category.categoryId,
                categoryName = category.categoryName,
            };
        }

        public static Expression<Func<Category, CategoryInfoDetails>> SelectExpressionCategoryDetails(this Category category)
        {
            return category => new CategoryInfoDetails
            {
                categoryId = category.categoryId,
                categoryName = category.categoryName,
                categoryDescription = category.categoryDescription,
            };
        }
    }
}