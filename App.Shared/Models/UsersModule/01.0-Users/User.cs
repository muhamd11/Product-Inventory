using App.Shared.Consts.Users;
using App.Shared.Models.Buyers;
using App.Shared.Models.SystemBase.BaseClass;
using App.Shared.Models.SystemBase.Roles;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Shared.Models.Users
{
    public class User : BaseEntity
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userPhone { get; set; }
        public string userPhoneCC { get; set; }
        public string userPhoneCCName { get; set; }
        public string userLoginName { get; set; }
        public string userPassword { get; set; }
        public EnumUserType userType { get; set; }
        //relations
        [ForeignKey(nameof(roleData))]
        public int systemRoleId { get; set; }
        public SystemRole roleData { get; set; }
        //using any user type type
        public UserProfile userProfile { get; set; }
        //using if user type is client
        public UserClient userBuyerData { get; set; }
    }

}