using App.Shared.Consts.Users;
using App.Shared.Models.SystemBase.BaseClass;
using System.Text.Json.Serialization;

namespace App.Shared.Models.SystemBase.Roles.ViewModel
{
    public class SystemRoleInfo : BaseEntityInfo
    {
        public int systemRoleId { get; set; }
        public string systemRoleName { get; set; }
        public EnumUserType systemRoleUserType { get; set; }
        public bool systemRoleCanUseDefault { get; set; }
    }
}