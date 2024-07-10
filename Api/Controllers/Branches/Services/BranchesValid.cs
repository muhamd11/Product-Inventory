using Api.Controllers.AdditionsModules.Branches.Interfaces;
using App.EF.Consts;
using App.Shared;
using App.Shared.Consts;
using App.Shared.Helper.Validations;
using App.Shared.Models.Branches.DTO;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Resources.Branches;
using App.Shared.Resources.General;

namespace Api.Controllers.Branchs.Services
{
    internal class BranchesValid : IBranchesValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public BranchesValid(IUnitOfWork unitOfWork)
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
                    var isValidBranchId = ValidBranchId(inputModel.elemetId.Value);
                    if (isValidBranchId.Status != EnumStatus.success)
                        return isValidBranchId;
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
                var isValidBranchId = ValidBranchId(inputModel.elementId);
                if (isValidBranchId.Status != EnumStatus.success)
                    return isValidBranchId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(BranchAddOrUpdateDTO inputModel, bool isUpdate)
        {
            if (inputModel is not null)
            {
                #region branchId?

                if (isUpdate)
                {
                    var isValidBranchId = ValidBranchId(inputModel.branchId);
                    if (isValidBranchId.Status != EnumStatus.success)
                        return isValidBranchId;
                }

                #endregion branchId?

                #region branchName *

                if (!ValidationClass.IsValidString(inputModel.branchContactInfo.branchName))
                    return BaseValid.createBaseValid(BranchesMessages.errorBranchNameIsRequired, EnumStatus.error);

                int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                if (!ValidationClass.IsValidStringLength(inputModel.branchContactInfo.branchName, nameMaxLength))
                    return BaseValid.createBaseValid(string.Format(GeneralMessages.errorNameLength, nameMaxLength), EnumStatus.error);

                #endregion branchName *

                #region branchAddress *

                if (!ValidationClass.IsValidString(inputModel.branchContactInfo.branchAddress))
                    return BaseValid.createBaseValid(BranchesMessages.errorBranchAddressIsRequired, EnumStatus.error);

                #endregion branchAddress *

                #region branchEmail ?

                if (!ValidationClass.IsValidEmail(inputModel.branchContactInfo.branchEmail))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidEmail, EnumStatus.error);

                #endregion branchEmail ?

                #region branchSocialMediaLinks ?

                if (!ValidationClass.IsValidUrl(inputModel.branchContactSocialMedia.branchWebsite))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidWebsiteUrl, EnumStatus.error);

                if (!ValidationClass.IsValidUrl(inputModel.branchContactSocialMedia.instagramLink))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidInstagramUrl, EnumStatus.error);

                if (!ValidationClass.IsValidUrl(inputModel.branchContactSocialMedia.twitterLink))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidTwitterUrl, EnumStatus.error);

                if (!ValidationClass.IsValidUrl(inputModel.branchContactSocialMedia.facebookLink))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidFacebookUrl, EnumStatus.error);

                if (!ValidationClass.IsValidUrl(inputModel.branchContactSocialMedia.youtubeLink))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidYoutubeUrl, EnumStatus.error);

                if (!ValidationClass.IsValidUrl(inputModel.branchContactSocialMedia.linkedinLink))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidLinkedinUrl, EnumStatus.error);

                #endregion branchSocialMediaLinks ?

                #region branchPhoneNumber ?

                if (!string.IsNullOrWhiteSpace(inputModel.branchContactInfo.branchPhoneNumber)
                    || !string.IsNullOrWhiteSpace(inputModel.branchContactInfo.branchCountryCode)
                    || !string.IsNullOrWhiteSpace(inputModel.branchContactInfo.branchCountryCodeName)
                    || !string.IsNullOrWhiteSpace(inputModel.branchContactInfo.branchDailCode))
                {
                    if (!ValidationClass.IsValidString(inputModel.branchContactInfo.branchPhoneNumber))
                        return BaseValid.createBaseValid(GeneralMessages.errorIsRequiredPhoneNumber, EnumStatus.error);

                    if (!ValidationClass.IsValidString(inputModel.branchContactInfo.branchCountryCode))
                        return BaseValid.createBaseValid(GeneralMessages.errorIsRequiredCountryCode, EnumStatus.error);

                    if (!ValidationClass.IsValidString(inputModel.branchContactInfo.branchCountryCodeName))
                        return BaseValid.createBaseValid(GeneralMessages.errorIsRequiredCountryCodeName, EnumStatus.error);

                    if (!ValidationClass.IsValidString(inputModel.branchContactInfo.branchDailCode))
                        return BaseValid.createBaseValid(GeneralMessages.errorIsRequiredDialCode, EnumStatus.error);

                    if (!ValidationClass.IsValidPhoneNumber(inputModel.branchContactInfo.branchCountryCode, inputModel.branchContactInfo.branchDailCode, inputModel.branchContactInfo.branchPhoneNumber))
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
                var isValidUintId = ValidBranchId(inputModel.elementId);
                if (isValidUintId.Status != EnumStatus.success)
                    return isValidUintId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidBranchId(int branchId)
        {
            var branch = _unitOfWork.Branches.FirstOrDefault(x => x.branchId == branchId);
            if (branch is not null)
                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);
        }

        #endregion Methods
    }
}