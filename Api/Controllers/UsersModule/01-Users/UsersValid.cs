using Api.Controllers.UsersModules.Users.Interfaces;
using App.EF.Consts;
using App.Shared;
using App.Shared.Consts;
using App.Shared.Helper.Validations;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.Users;
using App.Shared.Resources.General;
using App.Shared.Resources.UsersModules.User;

namespace Api.Controllers.UsersModule.Users
{
    internal class UserValid : IUserValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public UserValid(IUnitOfWork unitOfWork)
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
                    var isValidUserId = ValidUserId(inputModel.elemetId.Value);
                    if (isValidUserId.Status != EnumStatus.success)
                        return isValidUserId;
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
                var isValidUserId = ValidUserId(inputModel.elementId);
                if (isValidUserId.Status != EnumStatus.success)
                    return isValidUserId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(UserAddOrUpdateDTO inputModel, bool isUpdate)
        {
            if (inputModel is not null)
            {
                #region userId?

                if (isUpdate == true)
                {
                    var isValidUserId = ValidUserId(inputModel.userId);
                    if (isValidUserId.Status != EnumStatus.success)
                        return isValidUserId;
                }

                #endregion userId?

                #region userName *

                if (!ValidationClass.IsValidString(inputModel.userName))
                    return BaseValid.createBaseValid(UsersMessages.errorUsernameIsRequired, EnumStatus.error);

                int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                if (!ValidationClass.IsValidStringLength(inputModel.userName, nameMaxLength))
                    return BaseValid.createBaseValid(string.Format(GeneralMessages.errorNameLength, nameMaxLength), EnumStatus.error);

                #endregion userName *

                #region userEmail *

                //if (!ValidationClass.IsValidString(inputModel.userContanctInfo.userEmail))
                //    return BaseValid.createBaseValid(UsersMessages.errorEmailIsRequired, EnumStatus.error);

                //if (!ValidationClass.IsValidEmail(inputModel.userContanctInfo.userEmail))
                //    return BaseValid.createBaseValid(GeneralMessages.errorInvalidEmail, EnumStatus.error);

                #endregion userEmail *

                #region userPhoneNumber *

                //if (!ValidationClass.IsValidString(inputModel.userContanctInfo.userPhoneNumber))
                //    return BaseValid.createBaseValid(UsersMessages.errorPhoneNumberIsRequired, EnumStatus.error);

                //if (!ValidationClass.IsValidPhoneNumber(inputModel.userContanctInfo.userCountryCode, inputModel.userContanctInfo.userDailCode, inputModel.userContanctInfo.userPhoneNumber))
                //    return BaseValid.createBaseValid(GeneralMessages.ErrorInvalidPhoneNumber, EnumStatus.error);

                #endregion userPhoneNumber *

                #region ValidateUser

                var isValidUser = IsValidUser(inputModel);

                if (isValidUser.Status != EnumStatus.success)
                    return isValidUser;

                #endregion ValidateUser

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidUintId = ValidUserId(inputModel.elementId);
                if (isValidUintId.Status != EnumStatus.success)
                    return isValidUintId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidUserId(int userId)
        {
            var user = _unitOfWork.Users.FirstOrDefault(x => x.userId == userId);
            if (user is not null)
                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);
        }

        public BaseValid IsValidUser(UserAddOrUpdateDTO inputModel)
        {
            User existingUser;

            existingUser = _unitOfWork.Users.FirstOrDefault(x => x.userName == inputModel.userName);
            if (existingUser is not null && existingUser.userId != inputModel.userId)
                return BaseValid.createBaseValid(UsersMessages.errorUsernameWasAdded, EnumStatus.error);

            //existingUser = _unitOfWork.Users.FirstOrDefault(x => x.userContanctInfo.userEmail == inputModel.userContanctInfo.userEmail);
            //if (existingUser is not null && existingUser.userId != inputModel.userId)
            //    return BaseValid.createBaseValid(UsersMessages.errorUserEmailWasAdded, EnumStatus.error);

            //existingUser = _unitOfWork.Users.FirstOrDefault(x => x.userContanctInfo.userPhoneNumber == inputModel.userContanctInfo.userPhoneNumber);
            //if (existingUser is not null && existingUser.userId != inputModel.userId)
            //    return BaseValid.createBaseValid(UsersMessages.errorUserPhoneNumberWasAdded, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
        }

        #endregion Methods
    }
}