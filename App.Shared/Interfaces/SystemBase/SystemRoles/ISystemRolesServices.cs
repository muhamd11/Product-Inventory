using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.SystemBase.Roles.DTO;
using App.Shared.Models.SystemBase.Roles.ViewModel;
using System.Threading.Tasks;

namespace App.Shared.Interfaces.SystemBase.SystemRoles
{
    public interface ISystemRolesServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<SystemRoleInfo>> GetAllAsync(SystemRoleSearchDto inputModel);

        Task<SystemRoleInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<SystemRoleInfo>> AddOrUpdate(SystemRoleAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<SystemRoleInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}