using App.Shared.Models.SystemBase.Roles;
using App.Shared.Models.SystemBase.Roles.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.SystemRoles
{
    public static class SystemRolesAdaptor
    {
        public static Expression<Func<SystemRole, SystemRoleInfo>> SelectExpressionSystemRoleInfo()
        {
            return systemRole => new SystemRoleInfo
            {
                systemRoleId = systemRole.systemRoleId,
                systemRoleName = systemRole.systemRoleName,
            };
        }

        public static Expression<Func<SystemRole, SystemRoleInfoDetails>> SelectExpressionSystemRoleDetails()
        {
            return systemRole => new SystemRoleInfoDetails
            {
                systemRoleId = systemRole.systemRoleId,
                systemRoleName = systemRole.systemRoleName,
            };
        }

        public static SystemRoleInfo SelectExpressionSystemRoleInfo(SystemRole systemRole)
        {
            if (systemRole == null)
                return null;

            return new SystemRoleInfo
            {
                systemRoleId = systemRole.systemRoleId,
                systemRoleName = systemRole.systemRoleName,
            };
        }

        public static SystemRoleInfoDetails SelectExpressionSystemRoleDetails(SystemRole systemRole)
        {
            return new SystemRoleInfoDetails
            {
                systemRoleId = systemRole.systemRoleId,
                systemRoleName = systemRole.systemRoleName,
            };
        }
    }
}