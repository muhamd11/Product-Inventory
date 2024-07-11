using App.Shared;
using App.Shared.Consts.GeneralModels;
using App.Shared.Helper.Validations;
using App.Shared.Interfaces.SystemBase.SystemRoles;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.SystemBase.Roles;
using App.Shared.Models.SystemBase.Roles.DTO;
using App.Shared.Resources.General;
using App.Shared.Resources.SystemBase.SystemRoles;

namespace Api.Controllers.SystemBase.SystemRoles
{
    internal class SystemRoleValid : ISystemRolesValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public SystemRoleValid(IUnitOfWork unitOfWork)
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
                    var isValidSystemRoleId = ValidSystemRoleId(inputModel.elemetId.Value);
                    if (isValidSystemRoleId.Status != EnumStatus.success)
                        return isValidSystemRoleId;
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
                var isValidSystemRoleId = ValidSystemRoleId(inputModel.elementId);
                if (isValidSystemRoleId.Status != EnumStatus.success)
                    return isValidSystemRoleId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(SystemRoleAddOrUpdateDTO inputModel, bool isUpdate)
        {
            if (inputModel is not null)
            {
                #region systemRoleId?

                if (isUpdate == true)
                {
                    var isValidSystemRoleId = ValidSystemRoleId(inputModel.systemRoleId);
                    if (isValidSystemRoleId.Status != EnumStatus.success)
                        return isValidSystemRoleId;
                }

                #endregion systemRoleId?

                #region systemRoleName *

                if (!ValidationClass.IsValidString(inputModel.systemRoleName))
                    return BaseValid.createBaseValid(SystemRolesMessages.errorSystemRoleNameIsRequired, EnumStatus.error);

                int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                if (!ValidationClass.IsValidStringLength(inputModel.systemRoleName, nameMaxLength))
                    return BaseValid.createBaseValid(string.Format(GeneralMessages.errorNameLength, nameMaxLength), EnumStatus.error);

                #endregion systemRoleName *

                #region ValidateSystemRole

                var isValidSystemRole = IsValidSystemRole(inputModel);

                if (isValidSystemRole.Status != EnumStatus.success)
                    return isValidSystemRole;

                #endregion ValidateSystemRole

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidUintId = ValidSystemRoleId(inputModel.elementId);
                if (isValidUintId.Status != EnumStatus.success)
                    return isValidUintId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidSystemRoleId(int systemRoleId)
        {
            var systemRole = _unitOfWork.SystemRoles.FirstOrDefault(x => x.systemRoleId == systemRoleId);
            if (systemRole is not null)
                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);
        }

        public BaseValid IsValidSystemRole(SystemRoleAddOrUpdateDTO inputModel)
        {
            SystemRole existingSystemRole;

            existingSystemRole = _unitOfWork.SystemRoles.FirstOrDefault(x => x.systemRoleName == inputModel.systemRoleName);
            if (existingSystemRole is not null && existingSystemRole.systemRoleId != inputModel.systemRoleId)
                return BaseValid.createBaseValid(SystemRolesMessages.errorSystemRoleNameWasAdded, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
        }

        #endregion Methods
    }
}