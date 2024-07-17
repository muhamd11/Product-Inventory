using App.Shared.Models.Buyers;
using App.Shared.Models.Users;

namespace App.Shared.Models.UsersModule._01._1_UserTypes._01._2_UserClientData.DTO
{
    public class UserClientAddOrUpdateDTO : BaseUserAddOrUpdateDTO
    {
        public UserClient userClientData { get; set; }
    }
}