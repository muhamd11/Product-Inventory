using App.Shared.Interfaces;
using App.Shared.Models.AdditionsModules.CategoryModule;
using App.Shared.Models.AdditionsModules.ColorModule;
using App.Shared.Models.AdditionsModules.UnitModule;
using App.Shared.Models.Branches;
using App.Shared.Models.Products;
using App.Shared.Models.ProductStores;
using App.Shared.Models.Stores;
using System;
using System.Threading.Tasks;

namespace App.Shared

{
    public interface IUnitOfWork : IDisposable
    {
        #region CoreModules

        IBaseRepository<Product> Products { get; }
        IBaseRepository<Category> Categories { get; }
        IBaseRepository<ProductStore> ProductStores { get; }
        IBaseRepository<Store> Stores { get; }
        IBaseRepository<Branch> Branches { get; }

        #endregion CoreModules

        #region AdditionsModules

        IBaseRepository<Color> Colors { get; }
        IBaseRepository<Unit> Units { get; }

        #endregion AdditionsModules

        Task<int> CommitAsync();
    }
}