using App.Shared.Models.Roles;
using System.Linq.Expressions;

namespace Api.Controllers.Authorizations.Roles.Services
{
    public static class RoleAdaptor
    {
        public static Expression<Func<Role, RoleInfo>> SelectExpressionRoleInfo()
        {
            return role => new RoleInfo
            {
                roleId = role.roleId,
                roleName = role.roleName,
            };
        }

        public static Expression<Func<Role, RoleInfoDetails>> SelectExpressionRoleDetails()
        {
            return role => new RoleInfoDetails
            {
                roleId = role.roleId,
                roleName = role.roleName,
            };
        }

        public static RoleInfo SelectExpressionRoleInfo(Role role)
        {
            return new RoleInfo
            {
                roleId = role.roleId,
                roleName = role.roleName,
            };
        }

        public static RoleInfoDetails SelectExpressionRoleDetails(Role role)
        {
            return new RoleInfoDetails
            {
                roleId = role.roleId,
                roleName = role.roleName,
            };
        }
    }
}