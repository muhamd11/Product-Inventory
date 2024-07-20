using App.Shared.Models.Products;
using App.Shared.Models.Users;
using System.Collections.Generic;

namespace App.Shared.Models.ProductsModules._02._3._0_ProductWishlist.ViewModel
{
    public class WishlistInfo
    {
        public WishlistInfo()
        {
            wishlistProducts = new HashSet<WishlistProduct>();
        }

        public UserInfo userInfoData { get; set; }
        public ICollection<WishlistProduct> wishlistProducts { get; set; }

    }

    public class WishlistProduct
    {
        public ProductInfo productDataInfo { get; set; }
        public int productQuantity { get; set; }
    }
}