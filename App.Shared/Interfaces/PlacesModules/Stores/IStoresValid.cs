using App.Shared.Interfaces.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.PlacesModules.Stores.DTO;

namespace Api.Controllers.PlacesModules.Stores.Interfaces
{
    public interface IStoreValid : ITransientService
    {
        public BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        public BaseValid ValidGetAll(BaseSearchDto inputModel);

        public BaseValid ValidAddOrUpdate(StoreAddOrUpdateDTO inputModel, bool isUpdate);

        public BaseValid ValidDelete(BaseDeleteDto inputModel);

        public BaseValid ValidStoreId(int storeId);
    }
}