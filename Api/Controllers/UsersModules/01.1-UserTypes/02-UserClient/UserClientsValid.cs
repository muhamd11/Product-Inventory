using Api.Controllers.UsersModules.Users.Interfaces;
using App.Shared;
using App.Shared.Consts.GeneralModels;
using App.Shared.Consts.Users;
using App.Shared.Helper.Validations;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.UsersModule._01._1_UserTypes._01._2_UserClientData.DTO;
using App.Shared.Resources.General;

namespace Api.Controllers.UsersModule.Users
{
    internal class UserClientValid : IUserClientValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsersValid _baseUserValid;

        #endregion Members

        #region Constructor

        public UserClientValid(IUnitOfWork unitOfWork, IUsersValid baseUserValid)
        {
            _unitOfWork = unitOfWork;
            _baseUserValid = baseUserValid;
            
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
                    var isValidUserId = IsValidUserClientId(inputModel.elemetId.Value);
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
                var isValidUserId = IsValidUserClientId(inputModel.elementId);
                if (isValidUserId.Status != EnumStatus.success)
                    return isValidUserId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(UserClientAddOrUpdateDTO inputModel, bool isUpdate)
        {
            if (inputModel is not null)
            {
                #region userId?

                if (isUpdate)
                {
                    var isValidUserId = IsValidUserClientId(inputModel.userId);
                    if (isValidUserId.Status != EnumStatus.success)
                        return isValidUserId;
                }

                #endregion userId?

                #region ValidateUser

                var isValidUser = _baseUserValid.IsValidUser(inputModel);

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
                var isValidUintId = IsValidUserClientId(inputModel.elementId);
                if (isValidUintId.Status != EnumStatus.success)
                    return isValidUintId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }


        public BaseValid IsValidUserClientId(int userId)
        {
            var user = _unitOfWork.Users.FirstOrDefault(x => x.userId == userId && x.userType == EnumUserType.Client);
            if (user is not null)
                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);
        }


        #endregion Methods
    }
}