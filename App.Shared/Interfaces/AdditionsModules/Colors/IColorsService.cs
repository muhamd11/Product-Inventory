using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.AdditionsModules.Shared.Colors.DTO;
using App.Shared.Models.AdditionsModules.Shared.Colors.ViewModel;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using System.Threading.Tasks;

namespace App.Shared.Interfaces.AdditionsModules.Colors
{
    public interface IColorServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<ColorInfo>> GetAllAsync(ColorSearchDto inputModel);

        Task<ColorInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<ColorInfo>> AddOrUpdate(ColorAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<ColorInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}