using App.Shared.Models.Products;
using System.Collections.Generic;

namespace App.Shared.Models.ProductsModules._02._3._0_ProductWishlist.ViewModel
{
    public class WishlistInfo
    {
        public int userClientId { get; set; }
        public int wishlistId { get; set; }
        public ProductInfo productWishlist { get; set; }
        public int productQuantity { get; set; }
    }
}