using App.EF.Consts;
using App.Shared.Models.General;
using App.Shared.Models.UnitModule.ViewModel;
using System.Text.Json.Serialization;

namespace App.Shared.Models.UnitModule.Contracts.VM
{
    public class UnitGetDetailsResponse : BaseResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyOrder(4)]
        public UnitInfoDetails unitInfoData { get; set; }

        public UnitGetDetailsResponse CreateResponse(string message, EnumStatus status, UnitInfoDetails? data = null)
        {
            if (data == null)
                return new UnitGetDetailsResponse { Message = message, Status = status };

            return new UnitGetDetailsResponse { Message = message, Status = status, unitInfoData = data };
        }
    }
}