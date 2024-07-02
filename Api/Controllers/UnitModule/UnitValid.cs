using App.Core;
using App.EF.Consts;
using App.Shared.Consts;
using App.Shared.Helper.Validations;
using App.Shared.Models.General;
using App.Shared.Models.UnitModule.Contracts.DTO;
using App.Shared.Resources.General;
using App.Shared.Resources.UnitModules;

namespace Api.Controllers.UnitModule
{
    public class UnitValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public UnitValid(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion Constructor

        #region Methods

        public BaseValid ValidUnit(int unitId)
        {
            if (!ValidationClass.IsValidId(unitId))
                return BaseValid.createBaseValid(GeneralMessages.errorIdIsRequired, EnumStatus.error);

            var unit = _unitOfWork.Units.FirstOrDefault(x => x.unitId == unitId);

            if (unit == null || unit.unitId != unitId)
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
        }

        public BaseValid ValidUnitAdd(AddUnitDTO unitDto)
        {
            if (!ValidationClass.IsValidString(unitDto.Name))
                return BaseValid.createBaseValid(UnitsMessages.errorUnitNameIsRequired, EnumStatus.error);

            if (!ValidationClass.IsValidStringLength(unitDto.Name, 100))
                return BaseValid.createBaseValid(UnitsMessages.errorNameLength, EnumStatus.error);

            var unit = _unitOfWork.Units.FirstOrDefault(x => x.unitName == unitDto.Name);

            if (unit != null)
                return BaseValid.createBaseValid(GeneralMessages.wasAddedBefore, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessages.addSuccess, EnumStatus.success);
        }

        public BaseValid ValidUnitUpdate(UpdateUnitDTO unitDto)
        {
            if (!ValidationClass.IsValidString(unitDto.Name))
                return BaseValid.createBaseValid(UnitsMessages.errorUnitNameIsRequired, EnumStatus.error);

            if (!ValidationClass.IsValidStringLength(unitDto.Name, (int)EnumMaxLength.nameMaxLength))
                return BaseValid.createBaseValid(UnitsMessages.errorNameLength, EnumStatus.error);

            var unit = _unitOfWork.Units.FirstOrDefault(x => x.unitId == unitDto.Id);

            if (unit == null)
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);

            if (_unitOfWork.Units.Any(x => x.unitName == unitDto.Name && x.unitId != unitDto.Id))
                return BaseValid.createBaseValid(GeneralMessages.wasAddedBefore, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessages.updateSuccess, EnumStatus.success);
        }

        #endregion Methods
    }
}