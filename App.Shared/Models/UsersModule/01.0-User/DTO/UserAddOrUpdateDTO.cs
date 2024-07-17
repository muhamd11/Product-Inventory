using App.Shared.Consts.Users;
using App.Shared.Models.Buyers;
using App.Shared.Models.UsersModule._01._1_UserTypes.UserEmployee;

namespace App.Shared.Models.Users
{
    public class UserAddOrUpdateDTO
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

        public UserProfile userProfileData { get; set; } = new();
        public UserClient userClientData { get; set; } = new();
        public UserEmployee userEmployeeData { get; set; } = new();
    }
}