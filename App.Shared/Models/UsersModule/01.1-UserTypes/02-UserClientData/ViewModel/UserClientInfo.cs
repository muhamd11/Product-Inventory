using App.Shared.Models.ProductsModules._02._3._0_ProductWishlist.ViewModel;

namespace App.Shared.Models.UsersModule._01._1_UserTypes._02_UserClientData.ViewModel
{
    public class UserClientInfo
    {
        public string userShippingAddress { get; set; }
        public WishlistInfo userProductWishList { get; set; }
    }
}