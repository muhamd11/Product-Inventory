using Api.Controllers.SystemBase.LogActions.Interfaces;
using App.Shared;
using App.Shared.Consts.GeneralModels;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.UsersModule.LogActionsModel.DTO;
using App.Shared.Resources.General;

namespace Api.Controllers.SystemBase.LogActions
{
    internal class LogActionsValid : ILogActionsValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public LogActionsValid(IUnitOfWork unitOfWork)
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
                    var isValidLogActionId = ValidLogActionId(inputModel.elemetId.Value);
                    if (isValidLogActionId.Status != EnumStatus.success)
                        return isValidLogActionId;
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
                var isValidLogActionId = ValidLogActionId(inputModel.elementId);
                if (isValidLogActionId.Status != EnumStatus.success)
                    return isValidLogActionId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(LogActionAddOrUpdateDTO inputModel, bool isUpdate)
        {
            if (inputModel is not null)
            {
                #region loActionId?

                if (isUpdate == true)
                {
                    var isValidLogActionId = ValidLogActionId(inputModel.logActionId);
                    if (isValidLogActionId.Status != EnumStatus.success)
                        return isValidLogActionId;
                }

                #endregion loActionId?

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidLogActiontId = ValidLogActionId(inputModel.elementId);
                if (isValidLogActiontId.Status != EnumStatus.success)
                    return isValidLogActiontId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidLogActionId(int logActionId)
        {
            var logAction = _unitOfWork.LogActions.FirstOrDefault(x => x.logActionId == logActionId);
            if (logAction is not null)
                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);
        }

        #endregion Methods
    }
}