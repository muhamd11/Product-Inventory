using App.Shared.Interfaces.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.ProductStores.DTO;

namespace Api.Controllers.ProductsModules.ProductStores.Interfaces
{
    public interface IProductStoresValid : ITransientService
    {
        public BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        public BaseValid ValidGetAll(BaseSearchDto inputModel);

        public BaseValid ValidAddOrUpdate(ProductStoreAddOrUpdateDTO inputModel, bool isUpdate);

        public BaseValid ValidDelete(BaseDeleteDto inputModel);

        public BaseValid ValidProductProductId(int productProductId);
    }
}