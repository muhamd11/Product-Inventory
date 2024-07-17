using App.Shared.Models.Buyers;
using App.Shared.Models.SystemBase.Roles.ViewModel;
using App.Shared.Models.UsersModule._01._1_UserTypes._02_UserClientData.ViewModel;

namespace App.Shared.Models.Users
{
    public class UserInfoDetails : UserInfo
    {
        public int systemRoleId { get; set; }
        public SystemRoleInfo roleData { get; set; }
        public UserProfile userProfile { get; set; }
        public UserClientInfo userClientInfo { get; set; }
    }
}