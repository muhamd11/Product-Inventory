using App.Shared.Consts.Users;
using App.Shared.Models.General.BaseRequstModules;

namespace App.Shared.Models.SystemBase.Roles.DTO
{
    public class SystemRoleSearchDto : BaseSearchDto
    {
        public EnumUserType? systemRoleUserType { get; set; }
    }
}