

using System.Collections;
using System.Collections.Generic;

namespace App.Shared.Models.ProductModule
{
    public class Product
    {
        public Product()
        {
            productStoreData = new HashSet<ProductStore>();
        }
        public int productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }

        public ICollection<ProductStore> productStoreData { get; set; } 
    }
}
