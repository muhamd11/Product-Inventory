using App.Shared.Models.ProductsModules._02._3_ProductWishlist;
using App.Shared.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Shared.Models.Buyers
{
    public class UserClient
    {
        public int userClientId { get; set; }
        public string userShippingAddress { get; set; }
        [JsonIgnore,ForeignKey(nameof(userProductWishList))]
        public int? userProductWishListId { get; set; }
        [JsonIgnore]
        public Wishlist? userProductWishList { get; set; } = new();
    }
}