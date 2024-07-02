using App.EF.Consts;
using App.Shared.Models.ColorModule.ViewModel;
using App.Shared.Models.General;
using App.Shared.Resources.General;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace App.Shared.Models.ColorModule.Contracts.VM
{
    public class ColorGetAllResponse : BaseResponse
    {
        [JsonPropertyOrder(4)]
        public Pagination Pagination { get; set; }

        [JsonPropertyOrder(5)]
        public IEnumerable<ColorInfo> colorsInfoData { get; set; }

        public ColorGetAllResponse CreateResponseSuccessOrNoContent(IEnumerable<ColorInfo> data, Pagination? pagination = null)
        {
            pagination = pagination ?? new Pagination();

            if (!data.Any())
                return new ColorGetAllResponse { Message = GeneralMessages.errorDataNotFound, Status = EnumStatus.noContent };

            return new ColorGetAllResponse { Message = GeneralMessages.operationSuccess, Status = EnumStatus.success, colorsInfoData = data, Pagination = pagination };
        }

        public ColorGetAllResponse CreateResponseError(string message)
        {
            return new ColorGetAllResponse
            {
                Message = message,
                Status = EnumStatus.error,
            };
        }
    }
}