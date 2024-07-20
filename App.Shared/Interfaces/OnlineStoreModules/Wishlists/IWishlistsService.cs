using App.Shared.Interfaces.General.Scrutor;
using App.Shared.Models.General.BaseRequstModules;
using App.Shared.Models.General.LocalModels;
using App.Shared.Models.OnlineStoreModules._02._0_Wishlist.DTO;
using App.Shared.Models.ProductsModules._02._3._0_ProductWishlist.DTO;
using App.Shared.Models.ProductsModules._02._3._0_ProductWishlist.ViewModel;
using System.Threading.Tasks;

namespace App.Shared.Interfaces.OnlineStoreModules.Wishlists
{
    public interface IWishlistsService : ITransientService
    {
        Task<BaseGetDataWithPagnation<WishlistInfo>> GetAllAsync(WishlistSearchDto inputModel);
        Task<WishlistInfo> GetDetails(BaseGetDetailsDto inputModel);
        Task<BaseActionDone<WishlistInfo>> Update(WishlistUpdateDto inputModel);
    }
}