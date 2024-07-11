using Api.Controllers.PlacesModules.Stores.Interfaces;
using App.Shared;
using App.Shared.Consts.GeneralModels;
using App.Shared.Helper.Validations;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.PlacesModules.Stores.DTO;
using App.Shared.Resources.General;
using App.Shared.Resources.PlacesModules.Stores;

namespace Api.Controllers.PlacesModules.Stores
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
                var isValidStoreId = ValidStoreId(inputModel.elementId);
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

                if (isUpdate)
                {
                    var isValidStoreId = ValidStoreId(inputModel.storeId);
                    if (isValidStoreId.Status != EnumStatus.success)
                        return isValidStoreId;
                }

                #endregion storeId?

                #region storeName *

                if (!ValidationClass.IsValidString(inputModel.storeContactInfo.storeName))
                    return BaseValid.createBaseValid(StoresMessages.errorStoresNameIsRequired, EnumStatus.error);

                int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                if (!ValidationClass.IsValidStringLength(inputModel.storeContactInfo.storeName, nameMaxLength))
                    return BaseValid.createBaseValid(string.Format(GeneralMessages.errorNameLength, nameMaxLength), EnumStatus.error);

                #endregion storeName *

                #region storeAddress *

                if (!ValidationClass.IsValidString(inputModel.storeContactInfo.storeAddress))
                    return BaseValid.createBaseValid(StoresMessages.errorStoreAddressIsRequired, EnumStatus.error);

                #endregion storeAddress *

                #region storeEmail ?

                if (!ValidationClass.IsValidEmail(inputModel.storeContactInfo.storeEmail))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidEmail, EnumStatus.error);

                #endregion storeEmail ?

                #region storeSocialMediaLinks ?

                if (!ValidationClass.IsValidUrl(inputModel.storeContactSocialMedia.storeWebsite))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidWebsiteUrl, EnumStatus.error);

                if (!ValidationClass.IsValidUrl(inputModel.storeContactSocialMedia.instagramLink))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidInstagramUrl, EnumStatus.error);

                if (!ValidationClass.IsValidUrl(inputModel.storeContactSocialMedia.twitterLink))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidTwitterUrl, EnumStatus.error);

                if (!ValidationClass.IsValidUrl(inputModel.storeContactSocialMedia.facebookLink))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidFacebookUrl, EnumStatus.error);

                if (!ValidationClass.IsValidUrl(inputModel.storeContactSocialMedia.youtubeLink))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidYoutubeUrl, EnumStatus.error);

                if (!ValidationClass.IsValidUrl(inputModel.storeContactSocialMedia.linkedinLink))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidLinkedinUrl, EnumStatus.error);

                #endregion storeSocialMediaLinks ?

                #region branchPhoneNumber ?

                if (!string.IsNullOrWhiteSpace(inputModel.storeContactInfo.storePhoneNumber)
                    || !string.IsNullOrWhiteSpace(inputModel.storeContactInfo.storeCountryCode)
                    || !string.IsNullOrWhiteSpace(inputModel.storeContactInfo.storeCountryCodeName)
                    || !string.IsNullOrWhiteSpace(inputModel.storeContactInfo.storeDailCode))
                {
                    if (!ValidationClass.IsValidString(inputModel.storeContactInfo.storePhoneNumber))
                        return BaseValid.createBaseValid(GeneralMessages.errorIsRequiredPhoneNumber, EnumStatus.error);

                    if (!ValidationClass.IsValidString(inputModel.storeContactInfo.storeCountryCode))
                        return BaseValid.createBaseValid(GeneralMessages.errorIsRequiredCountryCode, EnumStatus.error);

                    if (!ValidationClass.IsValidString(inputModel.storeContactInfo.storeCountryCodeName))
                        return BaseValid.createBaseValid(GeneralMessages.errorIsRequiredCountryCodeName, EnumStatus.error);

                    if (!ValidationClass.IsValidString(inputModel.storeContactInfo.storeDailCode))
                        return BaseValid.createBaseValid(GeneralMessages.errorIsRequiredDialCode, EnumStatus.error);

                    if (!ValidationClass.IsValidPhoneNumber(inputModel.storeContactInfo.storeCountryCode, inputModel.storeContactInfo.storeDailCode, inputModel.storeContactInfo.storePhoneNumber))
                        return BaseValid.createBaseValid(GeneralMessages.ErrorInvalidPhoneNumber, EnumStatus.error);
                }

                #endregion branchPhoneNumber ?

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidUintId = ValidStoreId(inputModel.elementId);
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