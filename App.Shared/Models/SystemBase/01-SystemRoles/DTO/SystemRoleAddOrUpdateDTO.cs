using App.Shared.Consts.Users;

namespace App.Shared.Models.SystemBase.Roles.DTO
{
    public class SystemRoleAddOrUpdateDTO
    {
        public int systemRoleId { get; set; }
        public string systemRoleName { get; set; }
        public string systemRoleDescription { get; set; }
        public EnumUserType systemRoleUserType { get; set; }
        public bool systemRoleCanUseDefault { get; set; }
    }
}