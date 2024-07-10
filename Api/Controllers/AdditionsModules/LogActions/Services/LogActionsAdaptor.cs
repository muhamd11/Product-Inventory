using Api.Controllers.UsersModules.Users.Users.Services;
using App.Shared.Models.AdditionsModules.LogActionsModel;
using App.Shared.Models.AdditionsModules.LogActionsModel.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.LogActions.Services
{
    public static class LogActionsAdaptor
    {
        public static Expression<Func<LogAction, LogActionInfo>> SelectExpressionLogActionInfo()
        {
            return logAction => new LogActionInfo
            {
                logActionId = logAction.logActionId,
                logUser = UserAdaptor.SelectExpressionUserInfo(logAction.logUser),
                ModelName = logAction.ModelName,
                ActionDate = logAction.ActionDate,
                actionType = logAction.actionType
            };
        }

        public static Expression<Func<LogAction, LogActionInfoDetails>> SelectExpressionLogActionDetails()
        {
            return logAction => new LogActionInfoDetails
            {
                logActionId = logAction.logActionId,
                logUser = UserAdaptor.SelectExpressionUserInfo(logAction.logUser),
                ModelName = logAction.ModelName,
                ActionDate = logAction.ActionDate,
                actionType = logAction.actionType,
                oldActionData = logAction.oldActionData,
                newActionData = logAction.newActionData
            };
        }

        public static Expression<Func<LogAction, LogActionInfo>> SelectExpressionLogActionInfo(this LogAction loAction)
        {
            return logAction => new LogActionInfo
            {
                logActionId = logAction.logActionId,
                logUser = UserAdaptor.SelectExpressionUserInfo(logAction.logUser),
                ModelName = logAction.ModelName,
                ActionDate = logAction.ActionDate,
                actionType = logAction.actionType
            };
        }

        public static Expression<Func<LogAction, LogActionInfoDetails>> SelectExpressionLogActionDetails(this LogAction loAction)
        {
            return logAction => new LogActionInfoDetails
            {
                logActionId = logAction.logActionId,
                logUser = UserAdaptor.SelectExpressionUserInfo(logAction.logUser),
                ModelName = logAction.ModelName,
                ActionDate = logAction.ActionDate,
                actionType = logAction.actionType,
                oldActionData = logAction.oldActionData,
                newActionData = logAction.newActionData
            };
        }
    }
}