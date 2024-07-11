using App.Shared.Interfaces.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.PlacesModules.Branches.DTO;
using App.Shared.Models.PlacesModules.Branches.ViewModel;
using System.Threading.Tasks;

namespace Api.Controllers.PlacesModules.Branches.Interfaces
{
    public interface IBranchesService : ITransientService
    {
        Task<BaseGetDataWithPagnation<BranchInfo>> GetAllAsync(BranchSearchDto inputModel);

        Task<BranchInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<BranchInfo>> AddOrUpdate(BranchAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<BranchInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}