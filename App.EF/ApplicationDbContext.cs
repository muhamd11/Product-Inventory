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
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using App.Shared.Models.AdditionsModules.LogActionsModel.ViewModel;
using Newtonsoft.Json;
using App.Shared.Models.Base;
using App.Shared.Helper.Json;
using App.Shared.Helper.Validations;

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
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));


            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added) 
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.UtcNow;
                else if (entityEntry.State == EntityState.Modified)
                {
                    ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.UtcNow;
                    ((BaseEntity)entityEntry.Entity).CreatedDate = ((BaseEntity)entityEntry.Entity).CreatedDate;
                    ((BaseEntity)entityEntry.Entity).isDeleted = ((BaseEntity)entityEntry.Entity).isDeleted;
                }
                else if (entityEntry.State == EntityState.Deleted)
                {
                    ((BaseEntity)entityEntry.Entity).isDeleted = true;
                    ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.UtcNow;
                    ((BaseEntity)entityEntry.Entity).CreatedDate = ((BaseEntity)entityEntry.Entity).CreatedDate;
                }
            }

            var logEntries = ChangeTracker.Entries()
                   .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted))
                   .Select(e => CreateLogEntry(e))
                   .ToList(); // Collect log entries in a separate list

            // Add the log entries to the LogActions DbSet after enumeration is complete
            LogActions.AddRange(logEntries);
        }


        private LogAction CreateLogEntry(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry)
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
                logEntry.oldData = JsonConvert.SerializeObject(
                    entry.GetDatabaseValues().Properties.ToDictionary(p => p.Name, p => entry.OriginalValues[p]),
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