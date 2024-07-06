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
                var isValidBranchId = ValidBranchId(inputModel.elemetId);
                if (isValidBranchId.Status != EnumStatus.success)
                    return isValidBranchId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(BranchAddOrUpdateDTO inputModel, bool isUpdate)
        {
            //TODO: Continue Branch Validations

            if (inputModel is not null)
            {
                #region branchId?

                if (isUpdate == true)
                {
                    var isValidBranchId = ValidBranchId(inputModel.branchId);
                    if (isValidBranchId.Status != EnumStatus.success)
                        return isValidBranchId;
                }

                #endregion branchId?

                #region branchName *

                if (!ValidationClass.IsValidString(inputModel.branchName))
                    return BaseValid.createBaseValid(BranchesMessages.errorBranchNameIsRequired, EnumStatus.error);

                int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                if (!ValidationClass.IsValidStringLength(inputModel.branchName, nameMaxLength))
                    return BaseValid.createBaseValid(string.Format(GeneralMessages.errorNameLength, nameMaxLength), EnumStatus.error);

                var branch = _unitOfWork.Branches.FirstOrDefault(x => x.branchName == inputModel.branchName);
                if (branch != null && branch.branchId != inputModel.branchId)
                    return BaseValid.createBaseValid(BranchesMessages.errorBranchNameWasAdded, EnumStatus.error);

                #endregion branchName *

                #region branchAddress *

                if (!ValidationClass.IsValidString(inputModel.branchAddress))
                    return BaseValid.createBaseValid(BranchesMessages.errorBranchAddressIsRequired, EnumStatus.error);

                #endregion branchAddress *

                #region branchEmail ?
                if(!ValidationClass.IsValidEmail(inputModel.branchEmail))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidEmail, EnumStatus.error);

                #endregion branchEmail ?

                #region branchSocialMediaLinks ?

                if(!ValidationClass.IsValidUrl(inputModel.branchWebsite))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidWebsiteUrl, EnumStatus.error);

                if(!ValidationClass.IsValidUrl(inputModel.instagramLink))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidInstagramUrl, EnumStatus.error);

                if(!ValidationClass.IsValidUrl(inputModel.twitterLink))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidTwitterUrl, EnumStatus.error);

                if(!ValidationClass.IsValidUrl(inputModel.facebookLink))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidFacebookUrl, EnumStatus.error);

                if(!ValidationClass.IsValidUrl(inputModel.youtubeLink))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidYoutubeUrl, EnumStatus.error);

                if(!ValidationClass.IsValidUrl(inputModel.linkedinLink))
                    return BaseValid.createBaseValid(GeneralMessages.errorInvalidLinkedinUrl, EnumStatus.error);

                #endregion branchSocialMediaLinks ?

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidUintId = ValidBranchId(inputModel.elemetId);
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