using App.Core.Interfaces;
using App.Shared.Models.AdditionsModules.ColorModule;
using App.Shared.Models.AdditionsModules.UnitModule;
using System;
using System.Threading.Tasks;

namespace App.Core
{
    public interface IUnitOfWork : IDisposable
    {
        #region AdditionsModules

        IBaseRepository<Color> Colors { get; }
        IBaseRepository<Unit> Units { get; }

        #endregion AdditionsModules

        Task<int> CommitAsync();
    }
}