using App.Shared.Consts.SystemBase;
using App.Shared.Models.ProductsModules._02._3_ProductWishlist;
using App.Shared.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Shared.Models.Buyers
{
    [Table($"{nameof(UserClient)}s", Schema = nameof(EnumDatabaseSchema.Users))]

    public class UserClient
    {
        [JsonIgnore, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userClientId { get; set; }
        //relations
        [JsonIgnore, ForeignKey(nameof(User))]
        public int userId { get; set; }
    }
}