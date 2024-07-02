using App.Shared.Models.ColorModule.ViewModel;
using App.Shared.Models.UnitModule.ViewModel;

namespace App.Shared.Models.ProductModule.ViewModel
{
    public class ProductStoreInfo
    {
        public int productStoreId { get; set; }
        public ProductInfo productInfo { get; set; }
        public UnitInfo unitInfoData { get; set; }
        public ColorInfo colorInfoData { get; set; }
    }
}