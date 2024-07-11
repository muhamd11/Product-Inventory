using App.EF.Repositories;
using App.Shared;
using App.Shared.Interfaces.General;
using App.Shared.Models.AdditionsModules.Shared.Colors;
using App.Shared.Models.AdditionsModules.Shared.Units;
using App.Shared.Models.PlacesModules.Branches;
using App.Shared.Models.PlacesModules.Stores;
using App.Shared.Models.Products;
using App.Shared.Models.ProductsModules.Categories;
using App.Shared.Models.ProductStores;
using App.Shared.Models.SystemBase.Roles;
using App.Shared.Models.Users;
using App.Shared.Models.UsersModule.LogActionsModel;
using System.Threading.Tasks;

namespace App.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        #region AdditionsModules

        public IBaseRepository<Color> Colors { get; private set; }
        public IBaseRepository<Unit> Units { get; private set; }

        #endregion AdditionsModules

        #region PlacesModules

        public IBaseRepository<Store> Stores { get; private set; }
        public IBaseRepository<Branch> Branches { get; private set; }

        #endregion PlacesModules

        #region ProductsModules

        public IBaseRepository<Product> Products { get; private set; }
        public IBaseRepository<Category> Categories { get; private set; }
        public IBaseRepository<ProductStore> ProductStores { get; private set; }

        #endregion ProductsModules

        #region SystemBase

        public IBaseRepository<SystemRole> SystemRoles { get; private set; }
        public IBaseRepository<LogAction> LogActions { get; private set; }

        #endregion SystemBase

        #region UsersModule

        public IBaseRepository<User> Users { get; private set; }

        #endregion UsersModule

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            #region AdditionsModules

            Colors = new BaseRepository<Color>(_context);
            Units = new BaseRepository<Unit>(_context);

            #endregion AdditionsModules

            #region PlacesModules

            Stores = new BaseRepository<Store>(_context);
            Branches = new BaseRepository<Branch>(_context);

            #endregion PlacesModules

            #region ProductsModules

            Products = new BaseRepository<Product>(_context);
            Categories = new BaseRepository<Category>(_context);
            ProductStores = new BaseRepository<ProductStore>(_context);

            #endregion ProductsModules

            #region SystemBase

            SystemRoles = new BaseRepository<SystemRole>(_context);
            LogActions = new BaseRepository<LogAction>(_context);

            #endregion SystemBase

            #region UsersModule

            Users = new BaseRepository<User>(_context);

            #endregion UsersModule
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}