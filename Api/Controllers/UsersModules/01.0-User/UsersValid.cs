﻿using Api.Controllers.UsersModules.Users.Interfaces;
using App.Shared;
using App.Shared.Consts.GeneralModels;
using App.Shared.Consts.Users;
using App.Shared.Helper.Validations;
using App.Shared.Interfaces.SystemBase.SystemRoles;
using App.Shared.Interfaces.UsersModule.UserTypes.UserProfiles;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.Users;
using App.Shared.Resources.General;
using App.Shared.Resources.UsersModules.User;

namespace Api.Controllers.UsersModule.Users
{
    internal class UsersValid : IUsersValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly ISystemRolesValid _systemRolesValid;
        private readonly IUserProfileValid _userProfileValid;
        private readonly IUserClientsValid _userClientValid;

        #endregion Members

        #region Constructor

        public UsersValid(IUnitOfWork unitOfWork,
                         ISystemRolesValid systemRolesValid,
                         IUserProfileValid userProfileValid,
                         IUserClientsValid userClientValid)
        {
            _unitOfWork = unitOfWork;
            _systemRolesValid = systemRolesValid;
            _userProfileValid = userProfileValid;
            _userClientValid = userClientValid;
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
                    var isValidUserId = IsValidUserId(inputModel.elemetId.Value);
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
                var isValidUserId = IsValidUserId(inputModel.elementId);
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

                if (isUpdate)
                {
                    var isValidUserId = IsValidUserId(inputModel.userId);
                    if (isValidUserId.Status != EnumStatus.success)
                        return isValidUserId;
                }

                #endregion userId?

                #region userName &&  userLoginName && userEmail

                if (string.IsNullOrEmpty(inputModel.userName) && string.IsNullOrEmpty(inputModel.userEmail) && string.IsNullOrEmpty(inputModel.userPhone))
                    return BaseValid.createBaseValidError(GeneralMessages.errorSendLoginData);

                #endregion userName &&  userLoginName && userEmail

                #region userName ?

                if (!string.IsNullOrEmpty(inputModel.userName))
                {
                    int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                    if (!ValidationClass.IsValidStringLength(inputModel.userName, nameMaxLength))
                        return BaseValid.createBaseValid(string.Format(GeneralMessages.errorNameLength, nameMaxLength), EnumStatus.error);
                }

                #endregion userName ?

                #region userLoginName ?

                if (!string.IsNullOrEmpty(inputModel.userLoginName))
                {
                    if (!ValidationClass.IsValidString(inputModel.userLoginName))
                        return BaseValid.createBaseValid(UsersMessages.errorUserLoginNameIsRequired, EnumStatus.error);
                }

                #endregion userLoginName ?

                #region userEmail ?

                if (!string.IsNullOrEmpty(inputModel.userEmail))
                {
                    if (!ValidationClass.IsValidEmail(inputModel.userEmail))
                        return BaseValid.createBaseValid(GeneralMessages.errorInvalidEmail, EnumStatus.error);
                }

                #endregion userEmail ?

                #region userPhoneNumber *

                if (!ValidationClass.IsValidString(inputModel.userPhone))
                    return BaseValid.createBaseValid(UsersMessages.errorPhoneNumberIsRequired, EnumStatus.error);

                if (!ValidationClass.IsValidPhoneNumber(inputModel.userPhoneCC, inputModel.userPhoneDialCode, inputModel.userPhone))
                    return BaseValid.createBaseValid(GeneralMessages.ErrorInvalidPhoneNumber, EnumStatus.error);

                #endregion userPhoneNumber *

                #region userType *

                if (!ValidationClass.IsEnumValue<EnumUserType>(inputModel.userType))
                    return BaseValid.createBaseValid(UsersMessages.errorUserTypeInvalid, EnumStatus.error);

                #endregion userType *

                #region ValidSystemRoleId *

                var isValidSystemRoleId = _systemRolesValid.ValidSystemRoleId(inputModel.systemRoleId);
                if (isValidSystemRoleId.Status != EnumStatus.success)
                    return isValidSystemRoleId;

                #endregion ValidSystemRoleId *

                #region validUserWasAddedBefore

                var existingUser = _unitOfWork.Users.FirstOrDefault(x => x.userName == inputModel.userName
                 || x.userEmail == inputModel.userEmail
                 || x.userPhone == inputModel.userPhone
                 || x.userLoginName == inputModel.userLoginName);

                if (existingUser is not null && existingUser.userId != inputModel.userId && existingUser.userLoginName == inputModel.userLoginName)
                    return BaseValid.createBaseValid(UsersMessages.errorUsernameWasAdded, EnumStatus.error);

                if (existingUser is not null && existingUser.userId != inputModel.userId && existingUser.userEmail == inputModel.userEmail)
                    return BaseValid.createBaseValid(UsersMessages.errorUserEmailWasAdded, EnumStatus.error);

                if (existingUser is not null && existingUser.userId != inputModel.userId && existingUser.userPhone == inputModel.userPhone)
                    return BaseValid.createBaseValid(UsersMessages.errorUserPhoneNumberWasAdded, EnumStatus.error);

                if (existingUser is not null && existingUser.userId != inputModel.userId && existingUser.userLoginName == inputModel.userLoginName)
                    return BaseValid.createBaseValid(UsersMessages.errorUserLoginNameWasAdded, EnumStatus.error);

                #endregion validUserWasAddedBefore

                #region validUserProfile

                if (inputModel.userProfileData != null)
                {
                    var isValidUserProfile = _userProfileValid.IsValidUserProfile(inputModel.userProfileData);
                    if (isValidUserProfile.Status != EnumStatus.success)
                        return isValidUserProfile;
                }

                #endregion validUserProfile

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidUserId = IsValidUserId(inputModel.elementId);
                if (isValidUserId.Status != EnumStatus.success)
                    return isValidUserId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid IsValidUserId(int userId)
        {
            var user = _unitOfWork.Users.FirstOrDefault(x => x.userId == userId);
            if (user is not null)
                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);
        }

        #endregion Methods
    }
}