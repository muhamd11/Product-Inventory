using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.SystemBase.Roles.DTO;
using App.Shared.Models.SystemBase.Roles.ViewModel;
using System.Threading.Tasks;

namespace Api.Controllers.Authorizations.Roles.Interfaces
{
    public interface IRoleServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<RoleInfo>> GetAllAsync(RoleSearchDto inputModel);

        Task<RoleInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<RoleInfo>> AddOrUpdate(RoleAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<RoleInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}