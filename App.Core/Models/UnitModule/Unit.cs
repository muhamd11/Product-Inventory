using App.Shared.Models.ProductModule;
using System.Collections.Generic;

namespace App.Core.Models.UnitModule
{
    public class Unit
    {
        public Unit()
        {
            productStoreData = new HashSet<ProductStore>();
        }
        public int unitId { get; set; }
        public string unitName { get; set; }
        public string unitSympol { get; set; }
        public string unitDescription { get; set; }
        public ICollection<ProductStore> productStoreData { get; set; }

    }
}