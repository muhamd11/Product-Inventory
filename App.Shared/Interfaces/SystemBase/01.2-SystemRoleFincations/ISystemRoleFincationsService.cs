using Api.Controllers.SystemBase._01._2_SystemRoleFincations;
using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.SystemBase._01._2_SystemRoleFincations.DTO;
using App.Shared.Models.SystemBase._01._2_SystemRoleFincations.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers.SystemBase.LogActions.Interfaces
{
    public interface ISystemRoleFincationsService : ITransientService
    {
        Task<List<SystemRoleFunctionInfo>> GetDetails(int systemRoleId);

        Task<BaseActionDone<List<SystemRoleFincation>>> UpdatePrivilege(SystemRoleFincationDto inputModel);
    }
}