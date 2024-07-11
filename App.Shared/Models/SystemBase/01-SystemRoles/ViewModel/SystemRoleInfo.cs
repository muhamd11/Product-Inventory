using App.Shared.Consts.Users;
using App.Shared.Models.SystemBase.BaseClass;

namespace App.Shared.Models.SystemBase.Roles.ViewModel
{
    public class SystemRoleInfo
    {
        public int systemRoleId { get; set; }
        public string systemRoleName { get; set; }
        public EnumUserType systemRoleUserType { get; set; }
        public bool systemRoleCanUseDefault { get; set; }
        public BaseEntityInfo baseEntityInfo { get; set; }
    }
}