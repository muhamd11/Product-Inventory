using Api.Controllers.SystemBase._01._2_SystemRoleFincations;
using App.Shared.Interfaces.General;
using App.Shared.Models.AdditionsModules.Shared.Colors;
using App.Shared.Models.AdditionsModules.Shared.Units;
using App.Shared.Models.Buyers;
using App.Shared.Models.PlacesModules.Branches;
using App.Shared.Models.PlacesModules.Stores;
using App.Shared.Models.Products;
using App.Shared.Models.ProductsModules._02._3_ProductWishlist;
using App.Shared.Models.ProductsModules.Categories;
using App.Shared.Models.ProductStores;
using App.Shared.Models.SystemBase.Roles;
using App.Shared.Models.Users;
using App.Shared.Models.UsersModule._01._1_UserTypes.UserEmployee;
using App.Shared.Models.UsersModule.LogActionsModel;
using System;
using System.Threading.Tasks;

namespace App.Shared

{
    public interface IUnitOfWork : IDisposable
    {
        #region AdditionsModules

        IBaseRepository<Color> Colors { get; }
        IBaseRepository<Unit> Units { get; }

        #endregion AdditionsModules

        #region OnlineStoreModules

        IBaseRepository<Wishlist> UserWishlists { get; }

        #endregion OnlineStoreModules

        #region PlacesModules

        IBaseRepository<Store> Stores { get; }
        IBaseRepository<Branch> Branches { get; }

        #endregion PlacesModules

        #region ProductsModules

        IBaseRepository<Product> Products { get; }
        IBaseRepository<Category> Categories { get; }
        IBaseRepository<ProductStore> ProductStores { get; }

        #endregion ProductsModules

        #region SystemBase

        IBaseRepository<SystemRole> SystemRoles { get; }
        IBaseRepository<SystemRoleFincation> SystemRoleFincations { get; }
        IBaseRepository<LogAction> LogActions { get; }

        #endregion SystemBase

        #region UsersModule

        IBaseRepository<User> Users { get; }
        IBaseRepository<UserProfile> UserProfiles { get; }
        IBaseRepository<UserClient> UserClients { get; }
        IBaseRepository<UserEmployee> UserEmployees { get; }

        #endregion UsersModule

        Task<int> CommitAsync();
    }
}