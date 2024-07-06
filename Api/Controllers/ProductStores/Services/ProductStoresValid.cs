using Api.Controllers.AdditionsModules.Colors.Interfaces;
using Api.Controllers.AdditionsModules.ProductProducts.Interfaces;
using Api.Controllers.AdditionsModules.Products.Interfaces;
using Api.Controllers.AdditionsModules.Units.Interfaces;
using App.EF.Consts;
using App.Shared;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.ProductStores.DTO;
using App.Shared.Resources.General;

namespace Api.Controllers.ProductProducts.Services
{
    internal class ProductStoresValid : IProductStoresValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductValid _productsValid;
        private readonly ICategoriesValid _colorsValid;
        private readonly IUnitsValid _unitsValid;

        #endregion Members

        #region Constructor

        public ProductStoresValid(IUnitOfWork unitOfWork, IProductValid productsValid, ICategoriesValid colorsValid, IUnitsValid unitsValid)
        {
            _unitOfWork = unitOfWork;
            _productsValid = productsValid;
            _colorsValid = colorsValid;
            _unitsValid = unitsValid;
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
                    var isValidProductProductId = ValidProductProductId(inputModel.elemetId.Value);
                    if (isValidProductProductId.Status != EnumStatus.success)
                        return isValidProductProductId;
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
                var isValidProductProductId = ValidProductProductId(inputModel.elemetId);
                if (isValidProductProductId.Status != EnumStatus.success)
                    return isValidProductProductId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(ProductStoreAddOrUpdateDTO inputModel, bool isUpdate)
        {
            if (inputModel is not null)
            {
                #region productProductId?

                if (isUpdate == true)
                {
                    var isValidProductProductId = ValidProductProductId(inputModel.productStoreId);
                    if (isValidProductProductId.Status != EnumStatus.success)
                        return isValidProductProductId;
                }

                #endregion productProductId?

                #region productId *

                var isValidProductId = _productsValid.ValidProductId(inputModel.productId);
                if (isValidProductId.Status != EnumStatus.success)
                    return BaseValid.createBaseValid(isValidProductId.Message, isValidProductId.Status);

                #endregion productId *

                #region colorId *

                var isValidColorId = _colorsValid.ValidColorId(inputModel.colorId);
                if (isValidColorId.Status != EnumStatus.success)
                    return BaseValid.createBaseValid(isValidColorId.Message, isValidColorId.Status);

                #endregion colorId *

                #region productId *

                var isValidUnitId = _unitsValid.ValidUnitId(inputModel.unitId);
                if (isValidUnitId.Status != EnumStatus.success)
                    return BaseValid.createBaseValid(isValidUnitId.Message, isValidUnitId.Status);

                #endregion productId *

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidUintId = ValidProductProductId(inputModel.elemetId);
                if (isValidUintId.Status != EnumStatus.success)
                    return isValidUintId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidProductProductId(int productStoreId)
        {
            var productStore = _unitOfWork.ProductStores.FirstOrDefault(x => x.productStoreId == productStoreId);
            if (productStore is not null)
                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);
        }

        #endregion Methods
    }
}