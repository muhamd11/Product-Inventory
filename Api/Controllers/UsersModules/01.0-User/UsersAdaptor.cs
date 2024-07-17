using Api.Controllers.SystemBase.BaseEntitys;
using Api.Controllers.SystemBase.SystemRoles;
using App.Shared.Models.Users;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModule.Users
{
    public static class UsersAdaptor
    {
        public static Expression<Func<User, UserInfo>> SelectExpressionUserClientInfo()
        {
            return user => new UserInfo
            {
                userId = user.userId,
                userName = user.userName,
                userEmail = user.userEmail,
                userPhone = user.userPhone,
                userType = user.userType,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).isDeleted,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).createdDateTime,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).updatedDateTime,
                //TODO: Add Whislist Adaptor
            };
        }

        public static Expression<Func<User, UserInfoDetails>> SelectExpressionUserClientDetails()
        {
            return user => new UserInfoDetails
            {
                userId = user.userId,
                userName = user.userName,
                userEmail = user.userEmail,
                userPhone = user.userPhone,
                userType = user.userType,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).isDeleted,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).createdDateTime,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).updatedDateTime,
                systemRoleId = user.systemRoleId,
                roleData = SystemRolesAdaptor.SelectExpressionSystemRoleInfo(user.roleData),
                userProfile = user.userProfile,
                userClientInfo = UserClientsAdaptor.SelectExpressionUserClientInfo(user.userClientData),
            };
        }

        public static UserInfo SelectExpressionUserClientInfo(User user)
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
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).isDeleted,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).createdDateTime,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).updatedDateTime,
            };
        }

        public static UserInfoDetails SelectExpressionUserClientDetails(User user)
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
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).isDeleted,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).createdDateTime,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).updatedDateTime,
                systemRoleId = user.systemRoleId,
                roleData = SystemRolesAdaptor.SelectExpressionSystemRoleInfo(user.roleData),
                userProfile = user.userProfile,
                userClientInfo = UserClientsAdaptor.SelectExpressionUserClientInfo(user.userClientData),
            };
        }
    }
}