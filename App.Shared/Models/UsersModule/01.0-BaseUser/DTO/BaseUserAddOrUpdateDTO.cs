using App.Shared.Consts.Users;
using App.Shared.Models.Buyers;

namespace App.Shared.Models.Users
{
    public class BaseUserAddOrUpdateDTO
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public string userPhone { get; set; }
        public string userPhoneDialCode { get; set; }
        public string userPhoneCC { get; set; }
        public string userPhoneCCName { get; set; }
        public string userLoginName { get; set; }
        public string userPassword { get; set; }
        public EnumUserType userType { get; set; }

        //relations
        public int systemRoleId { get; set; }

        public UserProfile userProfile { get; set; } = new();
    }
}