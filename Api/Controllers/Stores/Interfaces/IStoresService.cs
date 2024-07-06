using Api.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.Stores;
using App.Shared.Models.Stores.DTO;

namespace Api.Controllers.AdditionsModules.Stores.Interfaces
{
    public interface IStoreServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<StoreInfo>> GetAllAsync(StoreSearchDto inputModel);

        Task<StoreInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<StoreInfo>> AddOrUpdate(StoreAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<StoreInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}