using App.Shared.Interfaces.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.UsersModule.LogActionsModel.DTO;
using App.Shared.Models.UsersModule.LogActionsModel.ViewModel;
using System.Threading.Tasks;

namespace Api.Controllers.SystemBase.LogActions.Interfaces
{
    public interface ILogActionServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<LogActionInfo>> GetAllAsync(LogActionSearchDto inputModel);

        Task<LogActionInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<LogActionInfo>> AddOrUpdate(LogActionAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<LogActionInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}