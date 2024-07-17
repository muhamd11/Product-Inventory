using App.Shared.Models.ProductsModules._02._3._0_ProductWishlist.ViewModel;
using App.Shared.Models.Users;
using System.Text.Json.Serialization;

namespace App.Shared.Models.UsersModule._01._1_UserTypes._02_UserClientData.ViewModel
{
    public class UserClientInfoDetails : BaseUserInfoDetails
    {
        public int userClientId { get; set; }
        public string userShippingAddress { get; set; }
        public WishlistInfo userProductWishList { get; set; }
    }
}