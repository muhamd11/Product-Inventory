using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.AdditionsModules.Shared.Units.DTO;
using App.Shared.Models.AdditionsModules.Shared.Units.ViewModel;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using System.Threading.Tasks;

namespace Api.Controllers.AdditionsModules.Shared.Units.Interfaces
{
    public interface IUnitServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<UnitInfo>> GetAllAsync(UnitSearchDto inputModel);

        Task<UnitInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<UnitInfo>> AddOrUpdate(UnitAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<UnitInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}