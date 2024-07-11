using Api.Controllers.Authorizations.Roles.Services;
using App.Shared.Models.Buyers;
using App.Shared.Models.Users;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModule.Users
{
    public static class UserAdaptor
    {
        public static Expression<Func<User, UserInfo>> SelectExpressionUserInfo()
        {
            return user => new UserInfo
            {
                userId = user.userId,
                userRoleInfo = user.roleData != null ? RoleAdaptor.SelectExpressionRoleInfo(user.roleData) : null,
            };
        }

        public static Expression<Func<User, UserInfoDetails>> SelectExpressionUserDetails()
        {
            return user => new UserInfoDetails
            {
                userId = user.userId,
                userRoleInfo = user.roleData != null ? RoleAdaptor.SelectExpressionRoleInfo(user.roleData) : null,
                userName = user.userName,
                userBuyerInfo = new UserClientInfo
                {
                    buyerFirstName = user.userBuyerData.buyerFirstName,
                    buyerLastName = user.userBuyerData.buyerLastName
                }
            };
        }

        public static UserInfo SelectExpressionUserInfo(User user)
        {
            return new UserInfo
            {
                userId = user.userId,
                userRoleInfo = user.roleData != null ? RoleAdaptor.SelectExpressionRoleInfo(user.roleData) : null,
            };
        }

        public static UserInfoDetails SelectExpressionUserDetails(User user)
        {
            return new UserInfoDetails
            {
                userId = user.userId,
                userRoleInfo = user.roleData != null ? RoleAdaptor.SelectExpressionRoleInfo(user.roleData) : null,
                userName = user.userName,
                userBuyerInfo = new UserClientInfo
                {
                    buyerFirstName = user.userBuyerData.buyerFirstName,
                    buyerLastName = user.userBuyerData.buyerLastName
                }
            };
        }
    }
}