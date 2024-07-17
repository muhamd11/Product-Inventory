using App.Shared.Models.Buyers;
using App.Shared.Models.UsersModule._01._1_UserTypes._02_UserClientData.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModule.Users
{
    public static class UserClientsAdaptor
    {
        public static Expression<Func<UserClient, UserClientInfo>> SelectExpressionUserClientInfo()
        {
            return user => new UserClientInfo
            {
                //TODO: Add Whislist Adaptor
            };
        }

        public static UserClientInfo SelectExpressionUserClientInfo(UserClient user)
        {
            if (user == null)
                return null;

            return new UserClientInfo
            {
                //TODO: Add Whislist Adaptor
            };
        }
    }
}