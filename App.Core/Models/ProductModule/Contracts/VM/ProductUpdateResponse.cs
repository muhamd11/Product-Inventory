using App.EF.Consts;
using App.Shared.Models.General;
using App.Shared.Models.ProductModule.ViewModel;
using App.Shared.Models.UnitModule.Contracts.VM;
using App.Shared.Models.UnitModule.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Shared.Models.ProductModule.Contracts.VM
{
    public class ProductUpdateResponse : BaseResponse
    {
        [JsonPropertyOrder(4)]
        public ProductInfoDetails productInfoData { get; set; }

        public ProductUpdateResponse CreateResponse(string message, EnumStatus status, ProductInfoDetails? data = null)
        {
            if (data == null)
                return new ProductUpdateResponse { Message = message, Status = status };

            return new ProductUpdateResponse { Message = message, Status = status, productInfoData = data };
        }
    }
}
