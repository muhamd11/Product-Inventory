using App.Shared.Models.PlacesModules.Stores;
using App.Shared.Models.PlacesModules.Stores.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.PlacesModules.Stores
{
    public static class StoreAdaptor
    {
        public static Expression<Func<Store, StoreInfo>> SelectExpressionStoreInfo()
        {
            return store => new StoreInfo
            {
                storeId = store.storeId,
                storeContactInfo = store.storeContactInfo,
            };
        }

        public static Expression<Func<Store, StoreInfoDetails>> SelectExpressionStoreDetails()
        {
            return store => new StoreInfoDetails
            {
                storeId = store.storeId,
                storeContactInfo = store.storeContactInfo,
                storeContactSocialMedia = store.storeContactSocialMedia,
                storeOpenAt = store.storeOpenAt,
                storeCloseAt = store.storeCloseAt,
            };
        }

        public static StoreInfo SelectExpressionStoreInfo(Store store)
        {
            return new StoreInfo
            {
                storeId = store.storeId,
                storeContactInfo = store.storeContactInfo,
            };
        }

        public static StoreInfoDetails SelectExpressionStoreDetails(Store store)
        {
            return new StoreInfoDetails
            {
                storeId = store.storeId,
                storeContactInfo = store.storeContactInfo,
                storeContactSocialMedia = store.storeContactSocialMedia,
                storeOpenAt = store.storeOpenAt,
                storeCloseAt = store.storeCloseAt,
            };
        }
    }
}