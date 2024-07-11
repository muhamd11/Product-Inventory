using App.Shared.Interfaces.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.Roles;
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