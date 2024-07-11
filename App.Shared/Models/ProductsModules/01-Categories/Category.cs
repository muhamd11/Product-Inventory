using App.Shared.Models.Products;
using System.Collections.Generic;

namespace App.Shared.Models.ProductsModules.Categories
{
    public class Category
    {
        public Category()
        {
            productsData = new HashSet<Product>();
        }

        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string categoryDescription { get; set; }
        public ICollection<Product> productsData { get; set; }
    }
}