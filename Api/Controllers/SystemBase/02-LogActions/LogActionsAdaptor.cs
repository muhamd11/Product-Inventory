using App.Shared.Models.UsersModule.LogActionsModel;
using App.Shared.Models.UsersModule.LogActionsModel.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.LogActions
{
    public static class LogActionsAdaptor
    {
        public static Expression<Func<LogAction, LogActionInfo>> SelectExpressionLogActionInfo()
        {
            return null;
        }

        public static Expression<Func<LogAction, LogActionInfoDetails>> SelectExpressionLogActionDetails()
        {
            return null;
        }

        public static Expression<Func<LogAction, LogActionInfo>> SelectExpressionLogActionInfo(this LogAction loAction)
        {
            return null;
        }

        public static Expression<Func<LogAction, LogActionInfoDetails>> SelectExpressionLogActionDetails(this LogAction loAction)
        {
            return null;
        }
    }
}