using System.Collections.Generic;

namespace App.Shared.Models.ProductsModules._02._3._0_ProductWishlist.DTO
{
    public class WishlistUpdateDto
    {
        public WishlistUpdateDto()
        {
            withListUpdateItems = new HashSet<WithListUpdateItems>();
        }

        public int userId { get; set; }
        public ICollection<WithListUpdateItems> withListUpdateItems { get; set; }
    }

    public class WithListUpdateItems
    {
        public int prodcutId { get; set; }
        public int productQuantity { get; set; }
    }
}