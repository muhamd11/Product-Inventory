using App.EF.Consts;
using App.Shared.Models.General;
using App.Shared.Models.ProductModule.ViewModel;
using App.Shared.Models.UnitModule.Contracts.VM;
using App.Shared.Models.UnitModule.ViewModel;
using App.Shared.Resources.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Shared.Models.ProductModule.Contracts.VM
{
    public class ProductStoreGetAllResponse : BaseResponse
    {
        [JsonPropertyOrder(4)]
        public Pagination pagination { get; set; }




    }
}
