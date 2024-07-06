using Api.Scrutor;
using App.Shared.Models.AdditionsModules.UnitModule.DTO;
using App.Shared.Models.AdditionsModules.UnitModule.ViewModel;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;

namespace Api.Controllers.AdditionsModules.Units.Interfaces
{
    public interface IUnitServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<UnitInfo>> GetAllAsync(UnitSearchDto inputModel);

        Task<UnitInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<UnitInfo>> AddOrUpdate(UnitAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<UnitInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}