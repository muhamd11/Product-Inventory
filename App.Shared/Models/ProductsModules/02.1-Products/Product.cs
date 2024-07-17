using App.Shared.Models.ProductsModules._02._3_ProductWishlist;
using System.Collections.Generic;

namespace App.Shared.Models.Products
{
    public class Product
    {
        public Product()
        {
            //productStoreData = new HashSet<ProductStore>();
            //categoryData = new HashSet<Category>();
            wishlistData = new HashSet<Wishlist>();
        }

        public int productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public ICollection<Wishlist> wishlistData { get; set; }
        //public ICollection<ProductStore> productStoreData { get; set; }
        //public ICollection<Category> categoryData { get; set; }
    }
}