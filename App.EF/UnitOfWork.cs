using App.Core;
using App.Core.Interfaces;
using App.EF.Repositories;
using App.Shared.Models.AdditionsModules.ColorModule;
using App.Shared.Models.AdditionsModules.UnitModule;
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

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            #region AdditionsModules

            Colors = new BaseRepository<Color>(_context);
            Units = new BaseRepository<Unit>(_context);

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