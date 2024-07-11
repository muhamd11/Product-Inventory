using App.EF.Repositories;
using App.Shared;
using App.Shared.Interfaces.General;
using App.Shared.Models.Products;
using App.Shared.Models.ProductStores;
using App.Shared.Models.Users;
using System.Threading.Tasks;

namespace App.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        #region CoreModules

        public IBaseRepository<User> Users { get; private set; }
        public IBaseRepository<Product> Products { get; private set; }
        public IBaseRepository<Category> Categories { get; private set; }

        public IBaseRepository<ProductStore> ProductStores { get; private set; }
        public IBaseRepository<Store> Stores { get; private set; }
        public IBaseRepository<Branch> Branches { get; private set; }

        #endregion CoreModules

        #region AdditionsModules

        public IBaseRepository<Color> Colors { get; private set; }
        public IBaseRepository<Unit> Units { get; private set; }
        public IBaseRepository<LogAction> LogActions { get; private set; }

        #endregion AdditionsModules

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            #region CoreModules

            Users = new BaseRepository<User>(_context);
            Products = new BaseRepository<Product>(_context);
            Categories = new BaseRepository<Category>(_context);
            ProductStores = new BaseRepository<ProductStore>(_context);
            Stores = new BaseRepository<Store>(_context);
            Branches = new BaseRepository<Branch>(_context);

            #endregion CoreModules

            #region AdditionsModules

            Colors = new BaseRepository<Color>(_context);
            Units = new BaseRepository<Unit>(_context);
            LogActions = new BaseRepository<LogAction>(_context);

            #endregion AdditionsModules
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