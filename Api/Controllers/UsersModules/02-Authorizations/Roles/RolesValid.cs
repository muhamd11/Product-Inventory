using Api.Controllers.Authorizations.Roles.Interfaces;
using App.Shared;
using App.Shared.Consts.GeneralModels;
using App.Shared.Helper.Validations;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.SystemBase.Roles;
using App.Shared.Models.SystemBase.Roles.DTO;
using App.Shared.Resources.General;
using App.Shared.Resources.UsersModules.Authorizations.Roles;

namespace Api.Controllers.Authorizations.Roles.Services
{
    internal class RoleValid : IRoleValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public RoleValid(IUnitOfWork unitOfWork)
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
                    var isValidRoleId = ValidRoleId(inputModel.elemetId.Value);
                    if (isValidRoleId.Status != EnumStatus.success)
                        return isValidRoleId;
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
                var isValidRoleId = ValidRoleId(inputModel.elementId);
                if (isValidRoleId.Status != EnumStatus.success)
                    return isValidRoleId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(RoleAddOrUpdateDTO inputModel, bool isUpdate)
        {
            if (inputModel is not null)
            {
                #region systemRoleId?

                if (isUpdate == true)
                {
                    var isValidRoleId = ValidRoleId(inputModel.systemRoleId);
                    if (isValidRoleId.Status != EnumStatus.success)
                        return isValidRoleId;
                }

                #endregion systemRoleId?

                #region systemRoleName *

                if (!ValidationClass.IsValidString(inputModel.systemRoleName))
                    return BaseValid.createBaseValid(RolesMessages.errorRoleNameIsRequired, EnumStatus.error);

                int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                if (!ValidationClass.IsValidStringLength(inputModel.systemRoleName, nameMaxLength))
                    return BaseValid.createBaseValid(string.Format(GeneralMessages.errorNameLength, nameMaxLength), EnumStatus.error);

                #endregion systemRoleName *

                #region ValidateRole

                var isValidRole = IsValidRole(inputModel);

                if (isValidRole.Status != EnumStatus.success)
                    return isValidRole;

                #endregion ValidateRole

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidUintId = ValidRoleId(inputModel.elementId);
                if (isValidUintId.Status != EnumStatus.success)
                    return isValidUintId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidRoleId(int systemRoleId)
        {
            var role = _unitOfWork.Roles.FirstOrDefault(x => x.systemRoleId == systemRoleId);
            if (role is not null)
                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);
        }

        public BaseValid IsValidRole(RoleAddOrUpdateDTO inputModel)
        {
            SystemRole existingRole;

            existingRole = _unitOfWork.Roles.FirstOrDefault(x => x.systemRoleName == inputModel.systemRoleName);
            if (existingRole is not null && existingRole.systemRoleId != inputModel.systemRoleId)
                return BaseValid.createBaseValid(RolesMessages.errorRoleNameWasAdded, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
        }

        #endregion Methods
    }
}