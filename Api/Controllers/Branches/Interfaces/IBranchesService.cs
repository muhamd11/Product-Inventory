using Api.Scrutor;
using App.Shared.Models.Branches;
using App.Shared.Models.Branches.DTO;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;

namespace Api.Controllers.AdditionsModules.Branches.Interfaces
{
    public interface IBranchesService : ITransientService
    {
        Task<BaseGetDataWithPagnation<BranchInfo>> GetAllAsync(BranchSearchDto inputModel);

        Task<BranchInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<BranchInfo>> AddOrUpdate(BranchAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<BranchInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}