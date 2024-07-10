using App.Shared.Models.AdditionsModules.CategoryModule;
using App.Shared.Models.AdditionsModules.ColorModule;
using App.Shared.Models.AdditionsModules.LogActionsModel;
using App.Shared.Models.AdditionsModules.UnitModule;
using App.Shared.Models.Branches;
using App.Shared.Models.Products;
using App.Shared.Models.ProductStores;
using App.Shared.Models.Stores;
using App.Shared.Models.Users;
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

        #region CoreModules

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductStore> ProductStores { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Branch> Branches { get; set; }

        #endregion CoreModules

        #region AdditionsModules

        public DbSet<Color> Colors { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<LogAction> LogActions { get; set; }

        #endregion AdditionsModules
    }
}