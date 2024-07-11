using Api.Controllers.ProductsModules.Categories.Interfaces;
using App.EF.Consts;
using App.Shared;
using App.Shared.Consts;
using App.Shared.Helper.Validations;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.ProductsModules.Categories;
using App.Shared.Models.ProductsModules.Categories.DTO;
using App.Shared.Resources.Category;
using App.Shared.Resources.General;

namespace Api.Controllers.ProductsModules.Categories.Services
{
    internal class CategoriesValid : ICategoriesValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public CategoriesValid(IUnitOfWork unitOfWork)
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
                    var isValidUintId = ValidCategoryId(inputModel.elemetId.Value);
                    if (isValidUintId.Status != EnumStatus.success)
                        return isValidUintId;
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
                var isValidUintId = ValidCategoryId(inputModel.elementId);
                if (isValidUintId.Status != EnumStatus.success)
                    return isValidUintId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(CategoryAddOrUpdateDTO inputModel, bool isUpdate)
        {
            if (inputModel is not null)
            {
                Category category;

                #region categoryId?

                if (isUpdate)
                {
                    var isValidUintId = ValidCategoryId(inputModel.categoryId);
                    if (isValidUintId.Status != EnumStatus.success)
                        return isValidUintId;
                }

                #endregion categoryId?

                #region categoryName *

                if (!ValidationClass.IsValidString(inputModel.categoryName))
                    return BaseValid.createBaseValid(CategoryMessages.errorCategoryNameIsRequired, EnumStatus.error);

                int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                if (!ValidationClass.IsValidStringLength(inputModel.categoryName, nameMaxLength))
                    return BaseValid.createBaseValid(string.Format(GeneralMessages.errorNameLength, nameMaxLength), EnumStatus.error);

                category = _unitOfWork.Categories.FirstOrDefault(x => x.categoryName == inputModel.categoryName);
                if (category != null && category.categoryId != inputModel.categoryId)
                    return BaseValid.createBaseValid(CategoryMessages.errorCategoryNameWasAdded, EnumStatus.error);

                #endregion categoryName *

                #region categoryDescription ?

                if (ValidationClass.IsValidString(inputModel.categoryDescription))
                {
                    int descriptionMaxLength = (int)EnumMaxLength.descriptionMaxLength;
                    if (!ValidationClass.IsValidStringLength(inputModel.categoryDescription, descriptionMaxLength))
                        return BaseValid.createBaseValid(string.Format(GeneralMessages.errorDescriptionMaxLength, descriptionMaxLength), EnumStatus.error);
                }

                #endregion categoryDescription ?

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            if (inputModel is not null)
            {
                var isValidUintId = ValidCategoryId(inputModel.elementId);
                if (isValidUintId.Status != EnumStatus.success)
                    return isValidUintId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidCategoryId(int categoryId)
        {
            var category = _unitOfWork.Categories.FirstOrDefault(x => x.categoryId == categoryId);
            if (category is not null)
                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);
        }

        #endregion Methods
    }
}