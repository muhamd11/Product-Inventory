using Api.Controllers.SystemBase._01._2_SystemRoleFincations;
using App.Shared.Consts.SystemBase;
using App.Shared.Models.Products;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Shared.Models.ProductsModules.Categories
{
    [Table($"Categories", Schema = nameof(EnumDatabaseSchema.Products))]

    public class Category
    {
        public Category()
        {
            productsData = new HashSet<Product>();
        }

        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string categoryDescription { get; set; }
        public ICollection<Product> productsData { get; set; }
    }
}