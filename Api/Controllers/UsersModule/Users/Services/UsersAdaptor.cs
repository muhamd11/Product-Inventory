using App.Shared.Models.Users;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModules.Users.Users.Services
{
    public static class UserAdaptor
    {
        public static Expression<Func<User, UserInfo>> SelectExpressionUserInfo()
        {
            return user => new UserInfo
            {
                userId = user.userId,
                userContanctInfo = user.userContanctInfo,
            };
        }

        public static Expression<Func<User, UserInfoDetails>> SelectExpressionUserDetails()
        {
            return user => new UserInfoDetails
            {
                userId = user.userId,
                userContanctInfo = user.userContanctInfo,
                userName = user.userName,
            };
        }

        public static UserInfo SelectExpressionUserInfo(User user)
        {
            return new UserInfo
            {
                userId = user.userId,
                userContanctInfo = user.userContanctInfo,
            };
        }

        public static UserInfoDetails SelectExpressionUserDetails(User user)
        {
            return new UserInfoDetails
            {
                userId = user.userId,
                userContanctInfo = user.userContanctInfo,
                userName = user.userName,
            };
        }
    }
}