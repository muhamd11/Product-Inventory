using Api.Controllers.ProductsModules.Products.Interfaces;
using App.Shared;
using App.Shared.Consts.GeneralModels;
using App.Shared.Interfaces.OnlineStoreModules.Wishlists;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.ProductsModules._02._3._0_ProductWishlist.DTO;
using App.Shared.Resources.General;

namespace Api.Controllers.OnlineStoreModules.Wishlists
{
    public class WishlistsValid : IWishlistsValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductValid _productValid;

        #endregion Members

        #region Constructor

        public WishlistsValid(IUnitOfWork unitOfWork, IProductValid productValid)
        {
            _unitOfWork = unitOfWork;
            _productValid = productValid;
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
                    var isValidProductId = ValidWishlistUserId(inputModel.elemetId.Value);
                    if (isValidProductId.Status != EnumStatus.success)
                        return isValidProductId;
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
                var isValidWishlistId = ValidWishlistUserId(inputModel.elementId);
                if (isValidWishlistId.Status != EnumStatus.success)
                    return isValidWishlistId;

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidUpdate(WishlistUpdateDto inputModel)
        {
            if (inputModel.withListUpdateItems is not null && inputModel.withListUpdateItems.Count > 0)
            {
                #region wishlistUserId?
                var isValidWishlistUserId = ValidWishlistUserId(inputModel.userId);
                if (isValidWishlistUserId.Status != EnumStatus.success)
                    return isValidWishlistUserId;

                #endregion wishlistUserId?

                foreach (var item in inputModel.withListUpdateItems)
                {
                    var isValidProductId = _productValid.ValidProductId(item.prodcutId);
                    if (isValidProductId.Status != EnumStatus.success)
                        return isValidProductId;
                }

                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessages.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidWishlistUserId(int userId)
        {
            var wishlist = _unitOfWork.UserWishlists.FirstOrDefault(x => x.userId == userId);
            if (wishlist is not null)
                return BaseValid.createBaseValid(GeneralMessages.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(GeneralMessages.errorDataNotFound, EnumStatus.error);
        }

        #endregion Methods

    }
}
