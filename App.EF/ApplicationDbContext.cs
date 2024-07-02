using App.Shared.Models.AdditionsModules.ColorModule;
using App.Shared.Models.AdditionsModules.UnitModule;
using Microsoft.EntityFrameworkCore;

namespace App.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        #region AdditionsModules

        public DbSet<Color> Colors { get; set; }
        public DbSet<Unit> Units { get; set; }

        #endregion AdditionsModules
    }
}