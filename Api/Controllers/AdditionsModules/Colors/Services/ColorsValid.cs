using Api.Controllers.AdditionsModules.Colors.Interfaces;
using App.Core;
using App.EF.Consts;
using App.Shared.Consts;
using App.Shared.Helper.Validations;
using App.Shared.Models.AdditionsModules.ColorModule;
using App.Shared.Models.AdditionsModules.ColorModule.DTO;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Resources.AdditionsModules.Colors;
using App.Shared.Resources.General;

namespace Api.Controllers.AdditionsModules.Colors.Services
{
    internal class ColorsValid : IColorsValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public ColorsValid(IUnitOfWork unitOfWork)
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

        public BaseValid ValidAddOrUpdate(ColorAddOrUpdateDTO inputModel, bool isUpdate)
        {
            if (inputModel is not null)
            {

                Color color;

                #region colorId?

                if (isUpdate == true)
                {
                    var isValidUintId = ValidUintId(inputModel.colorId);
                    if (isValidUintId.Status != EnumStatus.success)
                        return isValidUintId;
                }

                #endregion colorId?

                #region colorName *

                if (!ValidationClass.IsValidString(inputModel.colorName))
                    return BaseValid.createBaseValid(ColorsMessages.errorColorNameIsRequired, EnumStatus.error);

                int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                if (!ValidationClass.IsValidStringLength(inputModel.colorName, nameMaxLength))
                    return BaseValid.createBaseValid(string.Format(GeneralMessages.errorNameLength, nameMaxLength), EnumStatus.error);
                //TODO رسالة توضح ان الاسم اللون مضاف مسبقاً 
                color = _unitOfWork.Colors.FirstOrDefault(x => x.colorName == inputModel.colorName);
                if (color != null && color.colorId != inputModel.colorId)
                    return BaseValid.createBaseValid(GeneralMessages.wasAddedBefore, EnumStatus.error);

                #endregion colorName *

                #region colorHexCode *

                if (!ValidationClass.IsValidHexCode(inputModel.colorHexCode))
                    return BaseValid.createBaseValid(ColorsMessages.errorHexCodeFormat, EnumStatus.error);

                color = _unitOfWork.Colors.FirstOrDefault(x => x.colorHexCode == inputModel.colorHexCode);
                //TODO رسالة توضح ان كود اللون مضاف مسبقاً 
                if (color != null && color.colorId != inputModel.colorId)
                    return BaseValid.createBaseValid(GeneralMessages.wasAddedBefore, EnumStatus.error);
                #endregion colorHexCode *

                #region colorDescription ?

                if (ValidationClass.IsValidString(inputModel.colorDescription))
                {
                    int descriptionMaxLength = (int)EnumMaxLength.descriptionMaxLength;
                    if (!ValidationClass.IsValidStringLength(inputModel.colorDescription, descriptionMaxLength))
                        return BaseValid.createBaseValid(string.Format(GeneralMessages.errorDescriptionMaxLength, descriptionMaxLength), EnumStatus.error);
                }

                #endregion colorDescription ?

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

        public BaseValid ValidUintId(int colorId)
        {
            var color = _unitOfWork.Colors.FirstOrDefault(x => x.colorId == colorId);
            if (color is not null)
                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);
        }

        #endregion Methods
    }
}