using Api.Controllers.SystemBase.BaseEntitys;
using Api.Controllers.SystemBase.SystemRoles;
using App.Shared.Models.Users;
using App.Shared.Models.UsersModule._01._1_UserTypes._02_UserClientData.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModule.Users
{
    public static class UserProfilesAdaptor
    {
        public static Expression<Func<User, UserClientInfo>> SelectExpressionUserClientInfo()
        {
            return user => new UserClientInfo
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

        public static Expression<Func<User, UserClientInfoDetails>> SelectExpressionUserClientDetails()
        {
            return user => new UserClientInfoDetails
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
                userClientId = user.userClientData.userClientId,
                userShippingAddress = user.userClientData.userShippingAddress,
            };
        }

        public static UserClientInfo SelectExpressionUserClientInfo(User user)
        {
            if (user == null)
                return null;

            return new UserClientInfo
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

        public static UserClientInfoDetails SelectExpressionUserClientDetails(User user)
        {
            if (user == null)
                return null;
            return new UserClientInfoDetails
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
                userClientId = user.userClientData.userClientId,
                userShippingAddress = user.userClientData.userShippingAddress,
            };
        }
    }
}