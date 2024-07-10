using App.Shared.Models.AdditionsModules.LogActionsModel;
using App.Shared.Models.AdditionsModules.LogActionsModel.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.LogActions.Services
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