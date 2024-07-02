using App.Core;
using App.EF.Consts;
using App.Shared.Consts;
using App.Shared.Helper.Validations;
using App.Shared.Models.ColorModule.Contracts.DTO;
using App.Shared.Models.General;
using App.Shared.Models.ProductModule.Contracts.DTO;
using App.Shared.Resources.ColorsModule;
using App.Shared.Resources.General;

namespace Api.Controllers.ProductModule
{
    public class ProductValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public ProductValid(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion Constructor

        #region Methods

        public BaseValid ValidProduct(int productId)
        {
            if (!ValidationClass.IsValidId(productId))
                return BaseValid.createBaseValid(GeneralMessages.errorIdIsRequired, EnumStatus.error);

            var product = _unitOfWork.Products.FirstOrDefault(x => x.productId == productId);

            if (product == null || product.productId != productId)
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
        }

        public BaseValid ValidProductAdd(AddProductDTO productDto)
        {
            if (!ValidationClass.IsValidString(productDto.Name))
                return BaseValid.createBaseValid(GeneralMessages.errorNameIsRequired, EnumStatus.error);

            if (!ValidationClass.IsValidStringLength(productDto.Name, (int)EnumMaxLength.nameMaxLength))
                return BaseValid.createBaseValid(GeneralMessages.errorNameLength, EnumStatus.error);


            var color = _unitOfWork.Products.FirstOrDefault(x => x.productName == productDto.Name);

            if (color != null)
                return BaseValid.createBaseValid(GeneralMessages.wasAddedBefore, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessages.addSuccess, EnumStatus.success);
        }

        public BaseValid ValidProductUpdate(UpdateProductDTO productDto)
        {
            if (!ValidationClass.IsValidString(productDto.Name))
                return BaseValid.createBaseValid(GeneralMessages.errorNameIsRequired, EnumStatus.error);

            if (!ValidationClass.IsValidStringLength(productDto.Name, (int)EnumMaxLength.nameMaxLength))
                return BaseValid.createBaseValid(GeneralMessages.errorNameLength, EnumStatus.error);

            var product = _unitOfWork.Products.FirstOrDefault(x => x.productId == productDto.Id);

            if (product == null)
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);

            if (_unitOfWork.Products.Any(x => x.productName == productDto.Name && x.productId != productDto.Id))
                return BaseValid.createBaseValid(GeneralMessages.wasAddedBefore, EnumStatus.error);

            return BaseValid.createBaseValid(GeneralMessages.updateSuccess, EnumStatus.success);
        }

        #endregion Methods
    }
}
