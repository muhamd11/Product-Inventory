using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.ProductStores;
using App.Shared.Models.ProductStores.DTO;
using System.Threading.Tasks;

namespace Api.Controllers.ProductsModules.ProductStores.Interfaces
{
    public interface IProductStoreServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<ProductStoreInfo>> GetAllAsync(ProductStoreSearchDTO inputModel);

        Task<ProductStoreInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<ProductStoreInfo>> AddOrUpdate(ProductStoreAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<ProductStoreInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}