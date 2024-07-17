using App.Shared.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Shared.Models.ProductsModules._02._3_ProductWishlist
{
    public class Wishlist
    {
        public int wishlistId { get; set; }
        public int? userClientId { get; set; }
        [ForeignKey(nameof(productWishlistData))]
        public int? prodcutWishlistId { get; set; }
        public Product? productWishlistData { get; set; }
        public int productQuantity { get; set; }
    }
}