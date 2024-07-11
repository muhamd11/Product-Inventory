using App.Shared.Helper.Json;
using App.Shared.Models.AdditionsModules.Shared.Colors;
using App.Shared.Models.AdditionsModules.Shared.Units;
using App.Shared.Models.PlacesModules.Branches;
using App.Shared.Models.PlacesModules.Stores;
using App.Shared.Models.Products;
using App.Shared.Models.ProductsModules.Categories;
using App.Shared.Models.ProductStores;
using App.Shared.Models.SystemBase.BaseClass;
using App.Shared.Models.SystemBase.Roles;
using App.Shared.Models.Users;
using App.Shared.Models.UsersModule.LogActionsModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region override Configrations

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        #region override SaveChanges

        public override int SaveChanges()
        {
            LogChanges();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            LogChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void LogChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified
                                                                                                                     || e.State == EntityState.Deleted));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.UtcNow;
                else if (entityEntry.State == EntityState.Modified)
                    ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.UtcNow;
                else if (entityEntry.State == EntityState.Deleted)
                {
                    ((BaseEntity)entityEntry.Entity).isDeleted = true;
                    ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.UtcNow;
                }
            }

            var logEntries = ChangeTracker.Entries()
                                          .Select(CreateLogEntry)
                                          .ToList(); // Collect log entries in a separate list

            // Add the log entries to the LogActions DbSet after enumeration is complete
            LogActions.AddRange(logEntries);
        }

        private LogAction CreateLogEntry(EntityEntry entry)
        {
            var logEntry = new LogAction
            {
                userId = 0, // Replace with actual user identifier
                modelName = entry.Entity.GetType().Name,
                actionType = entry.State.ToString(),
                actionDate = DateTime.UtcNow
            };

            if (entry.State == EntityState.Modified)
            {
                var databaseValues = entry.GetDatabaseValues();
                logEntry.oldData = JsonConvert.SerializeObject(
                    databaseValues.Properties.ToDictionary(p => p.Name, p => databaseValues[p]),
                    JsonSettings.IgnoreSelfReferencesAndSpecificProperties);

                logEntry.newData = JsonConvert.SerializeObject(
                    entry.CurrentValues.Properties.ToDictionary(p => p.Name, p => entry.CurrentValues[p]),
                    JsonSettings.IgnoreSelfReferencesAndSpecificProperties);
            }
            else if (entry.State == EntityState.Deleted)
            {
                logEntry.oldData = JsonConvert.SerializeObject(
                    entry.OriginalValues.Properties.ToDictionary(p => p.Name, p => entry.OriginalValues[p]),
                    JsonSettings.IgnoreSelfReferencesAndSpecificProperties);
            }
            else if (entry.State == EntityState.Added)
            {
                logEntry.newData = JsonConvert.SerializeObject(
                    entry.CurrentValues.Properties.ToDictionary(p => p.Name, p => entry.CurrentValues[p]),
                    JsonSettings.IgnoreSelfReferencesAndSpecificProperties);
            }

            return logEntry;
        }

        #endregion override SaveChanges

        #endregion override Configrations

        #region DB Tables

        #region AdditionsModules

        public DbSet<Color> Colors { get; set; }
        public DbSet<Unit> Units { get; set; }

        #endregion AdditionsModules

        #region PlacesModules

        public DbSet<Store> Stores { get; set; }
        public DbSet<Branch> Branches { get; set; }

        #endregion PlacesModules

        #region ProductsModules

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductStore> ProductStores { get; set; }

        #endregion ProductsModules

        #region SystemBase

        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<LogAction> LogActions { get; set; }

        #endregion SystemBase

        #region UsersModule

        public DbSet<User> Users { get; set; }

        #endregion UsersModule

        #endregion DB Tables
    }
}