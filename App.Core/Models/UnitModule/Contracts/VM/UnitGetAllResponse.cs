using App.EF.Consts;
using App.Shared.Models.General;
using App.Shared.Models.UnitModule.ViewModel;
using App.Shared.Resources.General;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace App.Shared.Models.UnitModule.Contracts.VM
{
    public class UnitGetAllResponse : BaseResponse
    {
        [JsonPropertyOrder(4)]
        public Pagination Pagination { get; set; }

        [JsonPropertyOrder(5)]
        public IEnumerable<UnitInfo> unitsInfoData { get; set; }

        public UnitGetAllResponse CreateResponseSuccessOrNoContent(IEnumerable<UnitInfo> data, Pagination? pagination = null)
        {
            pagination = pagination ?? new Pagination();

            if (!data.Any())
                return new UnitGetAllResponse { Message = GeneralMessages.errorDataNotFound, Status = EnumStatus.noContent };

            return new UnitGetAllResponse { Message = GeneralMessages.operationSuccess, Status = EnumStatus.success, unitsInfoData = data, Pagination = pagination };
        }

        public UnitGetAllResponse CreateResponseError(string message)
        {
            return new UnitGetAllResponse
            {
                Message = message,
                Status = EnumStatus.error,
            };
        }
    }
}