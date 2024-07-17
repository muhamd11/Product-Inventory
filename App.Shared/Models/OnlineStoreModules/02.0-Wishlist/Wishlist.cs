using App.Shared.Models.Products;
using App.Shared.Models.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Shared.Models.ProductsModules._02._3_ProductWishlist
{
    public class Wishlist
    {
        public int wishlistId { get; set; }
        public int productQuantity { get; set; }
        //relations 
        [ForeignKey(nameof(userData))]
        public int? userId { get; set; }
        public User userData { get; set; }
        [ForeignKey(nameof(productData))]
        public int? prodcutId { get; set; }
        public Product productData { get; set; }
    }
}