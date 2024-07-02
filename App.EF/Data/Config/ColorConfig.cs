using App.Shared.Models.ColorModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.EF.Data.Config
{
    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(x => x.colorId);
            builder.Property(x => x.colorId).ValueGeneratedOnAdd();

            builder.Property(x => x.colorName).HasMaxLength(100);
            builder.Property(x => x.colorHexCode).HasMaxLength(8);
        }
    }
}