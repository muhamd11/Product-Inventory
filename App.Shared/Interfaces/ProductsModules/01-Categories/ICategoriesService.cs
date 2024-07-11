using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.ProductsModules.Categories.DTO;
using App.Shared.Models.ProductsModules.Categories.ViewModel;
using System.Threading.Tasks;

namespace Api.Controllers.ProductsModules.Categories.Interfaces
{
    public interface ICategoryServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<CategoryInfo>> GetAllAsync(CategorySearchDto inputModel);

        Task<CategoryInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<CategoryInfo>> AddOrUpdate(CategoryAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<CategoryInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}