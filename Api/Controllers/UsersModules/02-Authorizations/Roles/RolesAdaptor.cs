using App.Shared.Models.SystemBase.Roles;
using App.Shared.Models.SystemBase.Roles.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.Authorizations.Roles.Services
{
    public static class RoleAdaptor
    {
        public static Expression<Func<SystemRole, RoleInfo>> SelectExpressionRoleInfo()
        {
            return role => new RoleInfo
            {
                systemRoleId = role.systemRoleId,
                systemRoleName = role.systemRoleName,
            };
        }

        public static Expression<Func<SystemRole, RoleInfoDetails>> SelectExpressionRoleDetails()
        {
            return role => new RoleInfoDetails
            {
                systemRoleId = role.systemRoleId,
                systemRoleName = role.systemRoleName,
            };
        }

        public static RoleInfo SelectExpressionRoleInfo(SystemRole role)
        {
            return new RoleInfo
            {
                systemRoleId = role.systemRoleId,
                systemRoleName = role.systemRoleName,
            };
        }

        public static RoleInfoDetails SelectExpressionRoleDetails(SystemRole role)
        {
            return new RoleInfoDetails
            {
                systemRoleId = role.systemRoleId,
                systemRoleName = role.systemRoleName,
            };
        }
    }
}