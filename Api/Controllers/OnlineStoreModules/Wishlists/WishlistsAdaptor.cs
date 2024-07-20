using Api.Controllers.ProductsModules.Products.Services;
using Api.Controllers.UsersModule.Users;
using App.Shared.Models.ProductsModules._02._3._0_ProductWishlist.ViewModel;
using App.Shared.Models.ProductsModules._02._3_ProductWishlist;
using System.Linq.Expressions;

namespace Api.Controllers.OnlineStoreModules.Wishlists
{
    public static class WishlistsAdaptor
    {
        public static Expression<Func<Wishlist, WishlistInfo>> SelectExpressionWishlistInfo()
        {
            var wishlist = new Wishlist();
            var wishlistInfo = new WishlistInfo();
            wishlistInfo.userInfoData = UsersAdaptor.SelectExpressionUserClientInfo(wishlist.userData);

            foreach(var item in wishlistInfo.wishlistProducts)
            {
                item.productDataInfo = ProductAdaptor.SelectExpressionProductInfo(wishlist.productData);
                item.productQuantity = wishlist.productQuantity;
            }

            return wishlist => wishlistInfo;
        }

        public static WishlistInfo SelectExpressionWishlistInfo(Wishlist wishlist, int productCount)
        {
            if (wishlist == null)
                return null;

            var wishlistInfo = new WishlistInfo();

            var wishlistProducts = new List<WishlistProduct>();

            for(int i = 0; i < productCount; i++)
                wishlistProducts.Add(
                    new WishlistProduct()
                {
                    productDataInfo = ProductAdaptor.SelectExpressionProductInfo(wishlist.productData),
                    productQuantity = wishlist.productQuantity
                });


            wishlistInfo.userInfoData = UsersAdaptor.SelectExpressionUserClientInfo(wishlist.userData);
            wishlistInfo.wishlistProducts = wishlistProducts;

            return wishlistInfo;
        }
    }
}