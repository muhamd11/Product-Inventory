using App.Shared.Models.Stores;
using System.Linq.Expressions;

namespace Api.Controllers.AdditionsModules.Stores.Services
{
    public static class StoreAdaptor
    {
        public static Expression<Func<Store, StoreInfo>> SelectExpressionStoreInfo()
        {
            return store => new StoreInfo
            {
                storeId = store.storeId,
                storeName = store.storeName,
            };
        }

        public static Expression<Func<Store, StoreInfoDetails>> SelectExpressionStoreDetails()
        {
            return store => new StoreInfoDetails
            {
                storeId = store.storeId,
                storeName = store.storeName,
                storeAddress = store.storeAddress,
            };
        }

        public static StoreInfo SelectExpressionStoreInfo(Store store)
        {
            return new StoreInfo
            {
                storeId = store.storeId,
                storeName = store.storeName,
            };
        }

        public static StoreInfoDetails SelectExpressionStoreDetails(Store store)
        {
            return new StoreInfoDetails
            {
                storeId = store.storeId,
                storeName = store.storeName,
                storeAddress = store.storeAddress,
            };
        }
    }
}