using App.Shared.Models.Buyers;
using App.Shared.Models.Roles;

namespace App.Shared.Models.Users
{
    public class UserInfo
    {
        public int userId { get; set; }
        public RoleInfo? userRoleInfo { get; set; }
        public BuyerInfo userBuyerInfo { get; set; }
    }
}