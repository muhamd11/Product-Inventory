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
    public class ProductGetAllResponse : BaseResponse
    {
        [JsonPropertyOrder(4)]
        public Pagination Pagination { get; set; }

        [JsonPropertyOrder(5)]
        public IEnumerable<ProductInfo> productsInfoData { get; set; }

        public ProductGetAllResponse CreateResponseSuccessOrNoContent(IEnumerable<ProductInfo> data, Pagination? pagination = null)
        {
            pagination = pagination ?? new Pagination();

            if (!data.Any())
                return new ProductGetAllResponse { Message = GeneralMessages.errorDataNotFound, Status = EnumStatus.noContent };

            return new ProductGetAllResponse { Message = GeneralMessages.operationSuccess, Status = EnumStatus.success, productsInfoData = data, Pagination = pagination };
        }

        public ProductGetAllResponse CreateResponseError(string message)
        {
            return new ProductGetAllResponse
            {
                Message = message,
                Status = EnumStatus.error,
            };
        }
    }
}
