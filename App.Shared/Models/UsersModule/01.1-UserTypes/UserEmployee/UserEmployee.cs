using App.Shared.Consts.SystemBase;
using App.Shared.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace App.Shared.Models.UsersModule._01._1_UserTypes.UserEmployee
{
    [Table($"{nameof(UserEmployee)}s", Schema = nameof(EnumDatabaseSchema.Users))]
    public class UserEmployee
    {
        [JsonIgnore, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userEmployeetId { get; set; }

        //relations
        [JsonIgnore, ForeignKey(nameof(User))]
        public int userId { get; set; }
    }
}