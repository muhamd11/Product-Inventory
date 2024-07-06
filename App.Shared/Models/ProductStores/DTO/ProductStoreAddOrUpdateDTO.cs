namespace App.Shared.Models.ProductStores.DTO
{
    public class ProductStoreAddOrUpdateDTO
    {
        public int productStoreId { get; set; }
        public int productId { get; set; }
        public int unitId { get; set; }
        public int colorId { get; set; }
        public int quantity { get; set; }
    }
}