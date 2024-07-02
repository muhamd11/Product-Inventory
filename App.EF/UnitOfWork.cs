using App.Core;
using App.Core.Interfaces;
using App.Core.Models.UnitModule;
using App.EF.Data;
using App.EF.Repositories;
using App.Shared.Models.ColorModule;
using App.Shared.Models.ProductModule;
using System.Threading.Tasks;

namespace App.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepository<Unit> Units { get; private set; }
        public IBaseRepository<Color> Colors { get; private set; }
        public IBaseRepository<Product> Products { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Units = new BaseRepository<Unit>(_context);
            Colors = new BaseRepository<Color>(_context);
            Products = new BaseRepository<Product>(_context);
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