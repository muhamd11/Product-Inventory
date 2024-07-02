using App.EF.Consts;
using App.Shared.Models.ColorModule.ViewModel;
using App.Shared.Models.General;
using System.Text.Json.Serialization;

namespace App.Shared.Models.ColorModule.Contracts.VM
{
    public class ColorGetDetailsResponse : BaseResponse
    {
        [JsonPropertyOrder(4)]
        public ColorInfoDetails colorInfoData { get; set; }

        public ColorGetDetailsResponse CreateResponse(string message, EnumStatus status, ColorInfoDetails? data = null)
        {
            if (data == null)
                return new ColorGetDetailsResponse { Message = message, Status = status };

            return new ColorGetDetailsResponse { Message = message, Status = status, colorInfoData = data };
        }
    }
}