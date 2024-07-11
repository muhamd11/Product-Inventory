using App.Shared.Models.Buyers;
using App.Shared.Models.SystemBase.Roles.ViewModel;

namespace App.Shared.Models.Users
{
    public class UserInfoDetails : UserInfo
    {
        public int systemRoleId { get; set; }
        public SystemRoleInfo roleData { get; set; }
        public UserProfile userProfile { get; set; }
        public UserClient userBuyerData { get; set; }
    }
}