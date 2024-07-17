using App.Shared.Models.Buyers;
using App.Shared.Models.SystemBase.Roles.ViewModel;
using System.Text.Json.Serialization;

namespace App.Shared.Models.Users
{
    public class BaseUserInfoDetails : BaseUserInfo
    {
        public int systemRoleId { get; set; }
        public SystemRoleInfo roleData { get; set; }
        public UserProfile userProfile { get; set; }
    }
}