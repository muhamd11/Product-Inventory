using App.Shared.Models.ProductStores;
using App.Shared.Models.SystemBase.BaseClass;
using System.Collections.Generic;

namespace App.Shared.Models.AdditionsModules.Shared.Units
{
    public class Unit : BaseEntity
    {
        public Unit()
        {
            productStoresData = new HashSet<ProductStore>();
        }

        public int unitId { get; set; }
        public string unitName { get; set; }
        public string unitSympol { get; set; }
        public string unitDescription { get; set; }
        public ICollection<ProductStore> productStoresData { get; set; }
    }
}