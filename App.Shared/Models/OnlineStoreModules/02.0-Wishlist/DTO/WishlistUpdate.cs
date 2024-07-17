using System.Collections.Generic;

namespace App.Shared.Models.ProductsModules._02._3._0_ProductWishlist.DTO
{
    public class WishlistUpdate
    {
        public int userClientId { get; set; }
        public int wishlistId { get; set; }
        public int prodcutWishlistId { get; set; }
        public int productQuantity { get; set; }
    }
}