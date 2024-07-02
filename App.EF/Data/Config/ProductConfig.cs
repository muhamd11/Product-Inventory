using App.Shared.Models.ProductModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.EF.Data.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.productId);
            builder.Property(x => x.productId).ValueGeneratedOnAdd();
            builder.Property(x => x.productName).HasMaxLength(100);
            builder.Property(x => x.productDescription).HasMaxLength(500);

        }
    }
}
