using App.Shared.Models.General.BaseRequstModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Shared.Models.OnlineStoreModules._02._0_Wishlist.DTO
{
    public class WishlistSearchDto : BaseSearchDto
    {
        public int? userId { get; set; }
        public bool? userDataInclude { get; set; }
        public bool? productDataInclude { get; set; }
    }
}
