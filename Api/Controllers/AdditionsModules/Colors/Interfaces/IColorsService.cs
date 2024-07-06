using Api.Scrutor;
using App.Shared.Models.AdditionsModules.ColorModule.DTO;
using App.Shared.Models.AdditionsModules.ColorModule.ViewModel;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;

namespace Api.Controllers.AdditionsModules.Colors.Interfaces
{
    public interface IColorServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<ColorInfo>> GetAllAsync(ColorSearchDto inputModel);

        Task<ColorInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<ColorInfo>> AddOrUpdate(ColorAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<ColorInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}