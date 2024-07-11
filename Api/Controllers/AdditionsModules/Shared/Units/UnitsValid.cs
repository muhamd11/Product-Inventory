using Api.Controllers.AdditionsModules.Shared.Units.Interfaces;
using App.Shared;
using App.Shared.Consts.GeneralModels;
using App.Shared.Helper.Validations;
using App.Shared.Models.AdditionsModules.Shared.Units.DTO;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Resources.AdditionsModules.Shared.Units;
using App.Shared.Resources.General;

namespace Api.Controllers.AdditionsModules.Shared.Units.Services
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
                    var isValidUnitId = ValidUnitId(inputModel.elemetId.Value);
                    if (isValidUnitId.Status != EnumStatus.success)
                        return isValidUnitId;
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
                var isValidUnitId = ValidUnitId(inputModel.elementId);
                if (isValidUnitId.Status != EnumStatus.success)
                    return isValidUnitId;

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
                    var isValidUnitId = ValidUnitId(inputModel.unitId);
                    if (isValidUnitId.Status != EnumStatus.success)
                        return isValidUnitId;
                }

                #endregion unitId?

                #region unitName *

                if (!ValidationClass.IsValidString(inputModel.unitName))
                    return BaseValid.createBaseValid(UnitsMessages.errorUnitNameIsRequired, EnumStatus.error);

                int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                if (!ValidationClass.IsValidStringLength(inputModel.unitName, nameMaxLength))
                    return BaseValid.createBaseValid(string.Format(GeneralMessages.errorNameLength, nameMaxLength), EnumStatus.error);

                var unit = _unitOfWork.Units.FirstOrDefault(x => x.unitName == inputModel.unitName);
                if (unit != null && unit.unitId != inputModel.unitId)
                    return BaseValid.createBaseValid(UnitsMessages.errorUnitNameWasAdded, EnumStatus.error);

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
                var isValidUintId = ValidUnitId(inputModel.elementId);
                if (isValidUintId.Status != EnumStatus.success)
                    return isValidUintId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidUnitId(int unitId)
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