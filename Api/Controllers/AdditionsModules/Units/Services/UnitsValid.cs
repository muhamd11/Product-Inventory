using Api.Controllers.AdditionsModules.Units.Interfaces;
using App.Core;
using App.EF.Consts;
using App.Shared.Consts;
using App.Shared.Helper.Validations;
using App.Shared.Models.AdditionsModules.UnitModule.DTO;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Resources.AdditionsModules.Units;
using App.Shared.Resources.General;

namespace Api.Controllers.AdditionsModules.Units.Services
{
    internal class UnitsValid : IUnitsValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public UnitsValid(IUnitOfWork unitOfWork)
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
                    var isValidUintId = ValidUintId(inputModel.elemetId.Value);
                    if (isValidUintId.Status != EnumStatus.success)
                        return isValidUintId;
                }

                #endregion elemetId?

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidGetDetails(BaseGetDetalisDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidUintId = ValidUintId(inputModel.elemetId);
                if (isValidUintId.Status != EnumStatus.success)
                    return isValidUintId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(UnitAddOrUpdateDTO inputModel, bool isUpdate)
        {
            if (inputModel is not null)
            {
                #region unitId?

                if (isUpdate == true)
                {
                    var isValidUintId = ValidUintId(inputModel.unitId);
                    if (isValidUintId.Status != EnumStatus.success)
                        return isValidUintId;
                }

                #endregion unitId?

                #region unitName *

                if (!ValidationClass.IsValidString(inputModel.unitName))
                    return BaseValid.createBaseValid(UnitsMessages.errorUnitNameIsRequired, EnumStatus.error);

                int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                if (!ValidationClass.IsValidStringLength(inputModel.unitName, nameMaxLength))
                    return BaseValid.createBaseValid(string.Format(GeneralMessages.errorNameLength, nameMaxLength), EnumStatus.error);

                //TODO رسالة توضح ان الاسم اللون مضاف مسبقاً 
                var unit = _unitOfWork.Units.FirstOrDefault(x => x.unitName == inputModel.unitName);
                if (unit != null && unit.unitId != inputModel.unitId)
                    return BaseValid.createBaseValid(GeneralMessages.wasAddedBefore, EnumStatus.error);

                #endregion unitName *

                #region unitDescription ?

                if (ValidationClass.IsValidString(inputModel.unitDescription))
                {
                    int descriptionMaxLength = (int)EnumMaxLength.descriptionMaxLength;
                    if (!ValidationClass.IsValidStringLength(inputModel.unitDescription, descriptionMaxLength))
                        return BaseValid.createBaseValid(string.Format(GeneralMessages.errorDescriptionMaxLength, descriptionMaxLength), EnumStatus.error);
                }

                #endregion unitDescription ?

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidUintId = ValidUintId(inputModel.elemetId);
                if (isValidUintId.Status != EnumStatus.success)
                    return isValidUintId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidUintId(int unitId)
        {
            var unit = _unitOfWork.Units.FirstOrDefault(x => x.unitId == unitId);
            if (unit is not null)
                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);
        }

        #endregion Methods
    }
}