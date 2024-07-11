using App.Shared.Interfaces;
using App.Shared.Models.AdditionsModules.Shared.Colors;
using App.Shared.Models.AdditionsModules.Shared.Units;
using App.Shared.Models.PlacesModules.Branches;
using App.Shared.Models.PlacesModules.Stores;
using App.Shared.Models.Products;
using App.Shared.Models.ProductsModules.Categories;
using App.Shared.Models.ProductStores;
using App.Shared.Models.Roles;
using App.Shared.Models.Users;
using App.Shared.Models.UsersModule.LogActionsModel;
using System;
using System.Threading.Tasks;

namespace App.Shared

{
    public interface IUnitOfWork : IDisposable
    {
        #region CoreModules

        IBaseRepository<User> Users { get; }
        IBaseRepository<Product> Products { get; }
        IBaseRepository<Category> Categories { get; }
        IBaseRepository<ProductStore> ProductStores { get; }
        IBaseRepository<Store> Stores { get; }
        IBaseRepository<Branch> Branches { get; }

        #endregion CoreModules

        #region AdditionsModules

        IBaseRepository<Color> Colors { get; }
        IBaseRepository<Unit> Units { get; }
        IBaseRepository<Role> Roles { get; }
        IBaseRepository<LogAction> LogActions { get; }

        #endregion AdditionsModules

        Task<int> CommitAsync();
    }
}