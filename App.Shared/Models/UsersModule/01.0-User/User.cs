using App.Shared.Consts.SystemBase;
using App.Shared.Consts.Users;
using App.Shared.Models.Buyers;
using App.Shared.Models.SystemBase.BaseClass;
using App.Shared.Models.SystemBase.Roles;
using App.Shared.Models.UsersModule._01._1_UserTypes.UserEmployee;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Shared.Models.Users
{
    [Table($"{nameof(User)}s", Schema = nameof(EnumDatabaseSchema.Users))]
    [Index(nameof(userType))]
    [Index(nameof(userEmail), IsUnique = true)]
    [Index(nameof(userPhone), IsUnique = true)]
    [Index(nameof(userLoginName), IsUnique = true)]
    public class User : BaseEntity
    {
        [Key]
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
        [ForeignKey(nameof(roleData))]
        public int systemRoleId { get; set; }

        public SystemRole roleData { get; set; }

        //using any user type type
        public UserProfile userProfile { get; set; }

        //using if user type is client
        public UserClient userClientData { get; set; }

        //using if user type is client
        public UserEmployee userEmployeeData { get; set; }
    }
}