using Api.Controllers.SystemBase._01._2_SystemRoleFincations;
using App.Shared.Consts.SystemBase;
using App.Shared.Models.ProductsModules._02._3_ProductWishlist;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Shared.Models.Products
{
    [Table($"{nameof(Product)}s", Schema = nameof(EnumDatabaseSchema.Products))]

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