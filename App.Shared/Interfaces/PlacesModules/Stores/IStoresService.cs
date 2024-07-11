using App.Shared.Interfaces.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.PlacesModules.Stores.DTO;
using App.Shared.Models.PlacesModules.Stores.ViewModel;
using System.Threading.Tasks;

namespace Api.Controllers.PlacesModules.Stores.Interfaces
{
    public interface IStoreServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<StoreInfo>> GetAllAsync(StoreSearchDto inputModel);

        Task<StoreInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<StoreInfo>> AddOrUpdate(StoreAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<StoreInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}