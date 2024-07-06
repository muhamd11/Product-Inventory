using Api.Scrutor;
using App.Shared.Models.AdditionsModules.CategoryModule.DTO;
using App.Shared.Models.AdditionsModules.CategoryModule.ViewModel;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;

namespace Api.Controllers.AdditionsModules.Categories.Interfaces
{
    public interface ICategoryServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<CategoryInfo>> GetAllAsync(CategorySearchDto inputModel);

        Task<CategoryInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<CategoryInfo>> AddOrUpdate(CategoryAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<CategoryInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}