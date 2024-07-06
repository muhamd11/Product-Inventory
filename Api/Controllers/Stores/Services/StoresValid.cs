using Api.Controllers.AdditionsModules.Stores.Interfaces;
using App.EF.Consts;
using App.Shared;
using App.Shared.Consts;
using App.Shared.Helper.Validations;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.Stores.DTO;
using App.Shared.Resources.General;
using App.Shared.Resources.Stores;

namespace Api.Controllers.Stores.Services
{
    internal class StoreValid : IStoreValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public StoreValid(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion Constructor

        #region Methods

        public BaseValid ValidGetAll(BaseSearchDto inputModel)
        {
            if (inputModel is not null)
            {
                #region elemetId?

                if (inputModel.elemetId.HasValue)
                {
                    var isValidStoreId = ValidStoreId(inputModel.elemetId.Value);
                    if (isValidStoreId.Status != EnumStatus.success)
                        return isValidStoreId;
                }

                #endregion elemetId?

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidGetDetails(BaseGetDetailsDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidStoreId = ValidStoreId(inputModel.elemetId);
                if (isValidStoreId.Status != EnumStatus.success)
                    return isValidStoreId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(StoreAddOrUpdateDTO inputModel, bool isUpdate)
        {
            if (inputModel is not null)
            {
                #region storeId?

                if (isUpdate == true)
                {
                    var isValidStoreId = ValidStoreId(inputModel.storeId);
                    if (isValidStoreId.Status != EnumStatus.success)
                        return isValidStoreId;
                }

                #endregion storeId?

                #region storeName *

                if (!ValidationClass.IsValidString(inputModel.storeName))
                    return BaseValid.createBaseValid(StoresMessages.errorStoresNameIsRequired, EnumStatus.error);

                int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                if (!ValidationClass.IsValidStringLength(inputModel.storeName, nameMaxLength))
                    return BaseValid.createBaseValid(string.Format(GeneralMessages.errorNameLength, nameMaxLength), EnumStatus.error);

                var store = _unitOfWork.Stores.FirstOrDefault(x => x.storeName == inputModel.storeName);
                if (store != null && store.storeId != inputModel.storeId)
                    return BaseValid.createBaseValid(StoresMessages.errorStoresNameWasAdded, EnumStatus.error);

                #endregion storeName *

                #region storeAddress *

                if (!ValidationClass.IsValidString(inputModel.storeAddress))
                    return BaseValid.createBaseValid(StoresMessages.errorStoreAddressIsRequired, EnumStatus.error);

                #endregion storeAddress *

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidUintId = ValidStoreId(inputModel.elemetId);
                if (isValidUintId.Status != EnumStatus.success)
                    return isValidUintId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidStoreId(int storeId)
        {
            var store = _unitOfWork.Stores.FirstOrDefault(x => x.storeId == storeId);
            if (store is not null)
                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);
        }

        #endregion Methods
    }
}