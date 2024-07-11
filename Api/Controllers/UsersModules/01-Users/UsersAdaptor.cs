
using Api.Controllers.SystemBase.SystemRoles;
using App.Shared.Models.Users;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModule.Users
{
    public static class UsersAdaptor
    {
        public static Expression<Func<User, UserInfo>> SelectExpressionUserInfo()
        {
            return user => new UserInfo
            {
                userId = user.userId,
                userName = user.userName,
                userEmail = user.userEmail,
                userPhone = user.userPhone,
                userType = user.userType,
            };
        }

        public static Expression<Func<User, UserInfoDetails>> SelectExpressionUserDetails()
        {
            return user => new UserInfoDetails
            {
                userId = user.userId,
                userName = user.userName,
                userEmail = user.userEmail,
                userPhone = user.userPhone,
                userType = user.userType,
                systemRoleId = user.systemRoleId,
                roleData = SystemRolesAdaptor.SelectExpressionSystemRoleInfo(user.roleData),
                userProfile = user.userProfile,
                userBuyerData = user.userBuyerData,
            };
        }

        public static UserInfo SelectExpressionUserInfo(User user)
        {
            if (user == null)
                return null;

            return new UserInfo
            {
                userId = user.userId,
                userName = user.userName,
                userEmail = user.userEmail,
                userPhone = user.userPhone,
                userType = user.userType,
            };
        }

        public static UserInfoDetails SelectExpressionUserDetails(User user)
        {
            if (user == null)
                return null;
            return new UserInfoDetails
            {
                userId = user.userId,
                userName = user.userName,
                userEmail = user.userEmail,
                userPhone = user.userPhone,
                userType = user.userType,
                systemRoleId = user.systemRoleId,
                roleData = SystemRolesAdaptor.SelectExpressionSystemRoleInfo(user.roleData),
                userProfile = user.userProfile,
                userBuyerData = user.userBuyerData,
            };
        }
    }
}