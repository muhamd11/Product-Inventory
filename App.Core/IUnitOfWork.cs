using App.Core.Interfaces;
using App.Core.Models.UnitModule;
using App.Shared.Models.ColorModule;
using App.Shared.Models.ProductModule;
using System;
using System.Threading.Tasks;

namespace App.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Unit> Units { get; }
        IBaseRepository<Color> Colors { get; }
        IBaseRepository<Product> Products { get; }

        Task<int> CommitAsync();
    }
}