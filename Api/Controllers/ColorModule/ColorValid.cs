using App.Core;
using App.EF.Consts;
using App.Shared.Consts;
using App.Shared.Helper.Validations;
using App.Shared.Models.ColorModule.Contracts.DTO;
using App.Shared.Models.General;
using App.Shared.Resources.ColorsModule;
using App.Shared.Resources.General;

namespace Api.Controllers.ColorModule
{
    public class ColorValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public ColorValid(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion Constructor

        #region Methods

        public BaseValid ValidColor(int colorId)
        {
            if (!ValidationClass.IsValidId(colorId))
                return BaseValid.createBaseValid(GeneralMessages.errorIdIsRequired, EnumStatus.error);

            var color = _unitOfWork.Colors.FirstOrDefault(x => x.Id == colorId);

            if (color == null || color.Id != colorId)
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
        }

        public BaseValid ValidColorAdd(AddColorDTO colorDto)
        {
            if (!ValidationClass.IsValidString(colorDto.Name))
                return BaseValid.createBaseValid(ColorsMessages.errorColorNameIsRequired, EnumStatus.error);

            if (!ValidationClass.IsValidStringLength(colorDto.Name, (int)EnumMaxLength.nameMaxLength))
                return BaseValid.createBaseValid(ColorsMessages.errorNameLength, EnumStatus.error);

            if (!ValidationClass.IsValidHexCode(colorDto.HexCode))
                return BaseValid.createBaseValid(ColorsMessages.errorHexCodeFormat, EnumStatus.error);

            if (_unitOfWork.Colors.Any(x => x.HexCode == colorDto.HexCode))
                return BaseValid.createBaseValid(ColorsMessages.errorHexCodeWasAddedBefore, EnumStatus.error);

            var color = _unitOfWork.Colors.FirstOrDefault(x => x.Name == colorDto.Name || x.HexCode == colorDto.HexCode);

            if (color != null)
                return BaseValid.createBaseValid(GeneralMessages.wasAddedBefore, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessages.addSuccess, EnumStatus.success);
        }

        public BaseValid ValidColorUpdate(UpdateColorDTO colorDto)
        {
            if (!ValidationClass.IsValidString(colorDto.Name))
                return BaseValid.createBaseValid(ColorsMessages.errorColorNameIsRequired, EnumStatus.error);

            if (!ValidationClass.IsValidStringLength(colorDto.Name, 100))
                return BaseValid.createBaseValid(ColorsMessages.errorNameLength, EnumStatus.error);

            if (!ValidationClass.IsValidHexCode(colorDto.HexCode))
                return BaseValid.createBaseValid(ColorsMessages.errorHexCodeFormat, EnumStatus.error);

            var color = _unitOfWork.Colors.FirstOrDefault(x => x.Id == colorDto.Id);

            if (color == null)
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);

            if (_unitOfWork.Colors.Any(x => x.Name == colorDto.Name && x.Id != colorDto.Id))
                return BaseValid.createBaseValid(GeneralMessages.wasAddedBefore, EnumStatus.error);

            if (_unitOfWork.Colors.Any(x => x.HexCode == colorDto.HexCode && x.Id != colorDto.Id))
                return BaseValid.createBaseValid(ColorsMessages.errorHexCodeWasAddedBefore, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessages.updateSuccess, EnumStatus.success);
        }

        #endregion Methods
    }
}