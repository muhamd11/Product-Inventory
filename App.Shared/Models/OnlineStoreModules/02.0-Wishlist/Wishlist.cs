using App.Shared.Consts.SystemBase;
using App.Shared.Models.Products;
using App.Shared.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Shared.Models.ProductsModules._02._3_ProductWishlist
{
    [Table($"{nameof(Wishlist)}s", Schema = nameof(EnumDatabaseSchema.OnlineStores))]
    public class Wishlist
    {
        public int wishlistId { get; set; }

        //relations
        [ForeignKey(nameof(userData))]
        public int? userId { get; set; }

        public User userData { get; set; }

        [ForeignKey(nameof(productData))]
        public int? prodcutId { get; set; }

        public Product productData { get; set; }

        public int productQuantity { get; set; }

    }

}