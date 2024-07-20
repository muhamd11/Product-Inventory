using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.ProductsModules._02._3._0_ProductWishlist.DTO;

namespace App.Shared.Interfaces.OnlineStoreModules.Wishlists
{
    public interface IWishlistsValid : ITransientService
    {
        BaseValid ValidGetAll(BaseSearchDto inputModel);
        BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);
        BaseValid ValidUpdate(WishlistUpdateDto inputModel);
        BaseValid ValidWishlistUserId(int userId);
    }
}