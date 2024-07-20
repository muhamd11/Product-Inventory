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
            return wishlist => new WishlistInfo
            {
                productDataInfo = ProductAdaptor.SelectExpressionProductInfo(wishlist.productData),
                productQuantity= wishlist.productQuantity
            };
        }
 
        public static Expression<Func<Wishlist, WishlistInfo>> SelectExpressionWishlistInfo(this Wishlist wishlist)
        {
            return wishlist => new WishlistInfo
            {
                productDataInfo = ProductAdaptor.SelectExpressionProductInfo(wishlist.productData),
                productQuantity = wishlist.productQuantity
            };
        }

     }

}