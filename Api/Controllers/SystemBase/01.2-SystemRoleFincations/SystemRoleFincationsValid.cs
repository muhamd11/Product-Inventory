using Api.Controllers.SystemBase.LogActions.Interfaces;
using App.Shared;
using App.Shared.Consts.GeneralModels;
using App.Shared.Interfaces.SystemBase.SystemRoles;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.SystemBase._01._2_SystemRoleFincations.DTO;
using App.Shared.Resources.General;

namespace Api.Controllers.SystemBase.SystemRoleFincations
{
    internal class SystemRoleFincationValid : ISystemRoleFincationsValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly ISystemRolesValid _systemRolesValid;

        #endregion Members

        #region Constructor

        public SystemRoleFincationValid(IUnitOfWork unitOfWork, ISystemRolesValid systemRolesValid)
        {
            _unitOfWork = unitOfWork;
            _systemRolesValid = systemRolesValid;
        }

        #endregion Constructor

        #region Methods

        public BaseValid ValidGetDetails(int systemRoleId)
        {
            var isValidSystemRoleId = _systemRolesValid.ValidSystemRoleId(systemRoleId);

            if (isValidSystemRoleId.Status != EnumStatus.success)
                return isValidSystemRoleId;

            return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
        }

        public BaseValid ValidUpdatePrivlage(SystemRoleFincationDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidSystemRoleId = _systemRolesValid.ValidSystemRoleId(inputModel.systemRoleId);

                if (isValidSystemRoleId.Status != EnumStatus.success)
                    return isValidSystemRoleId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);

        }
        #endregion Methods
    }
}