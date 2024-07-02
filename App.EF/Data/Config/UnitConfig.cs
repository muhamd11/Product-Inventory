using App.Core.Models.UnitModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.EF.Data.Config
{
    public class UnitConfig : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasKey(x => x.unitId);
            builder.Property(x => x.unitId).ValueGeneratedOnAdd();

            builder.Property(x => x.unitDescription).HasMaxLength(500);
        }
    }
}