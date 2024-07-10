using Api.Scrutor;
using App.Shared.Models.AdditionsModules.LogActionsModel;
using App.Shared.Models.AdditionsModules.LogActionsModel.DTO;
using App.Shared.Models.AdditionsModules.LogActionsModel.ViewModel;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;

namespace Api.Controllers.AdditionsModules.LogActions.Interfaces
{
    public interface ILogActionServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<LogActionInfo>> GetAllAsync(LogActionSearchDto inputModel);

        Task<LogActionInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<LogActionInfo>> AddOrUpdate(LogActionAddOrUpdateDTO inputModel, bool isUpdate)

        Task<BaseActionDone<LogActionInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}