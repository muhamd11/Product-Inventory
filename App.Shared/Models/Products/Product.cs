using App.Shared.Models.AdditionsModules.CategoryModule;
using App.Shared.Models.ProductStores;
using System.Collections.Generic;

namespace App.Shared.Models.Products
{
    public class Product
    {
        public Product()
        {
            //productStoreData = new HashSet<ProductStore>();
            //categoryData = new HashSet<Category>();
        }

        public int productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        //public ICollection<ProductStore> productStoreData { get; set; }
        //public ICollection<Category> categoryData { get; set; }
    }
}