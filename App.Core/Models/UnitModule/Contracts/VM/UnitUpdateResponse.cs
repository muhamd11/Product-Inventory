using App.EF.Consts;
using App.Shared.Models.General;
using App.Shared.Models.UnitModule.ViewModel;
using System.Text.Json.Serialization;

namespace App.Shared.Models.UnitModule.Contracts.VM
{
    public class UnitUpdateResponse : BaseResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyOrder(4)]
        public UnitInfoDetails unitInfoData { get; set; }

        public UnitUpdateResponse CreateResponse(string message, EnumStatus status, UnitInfoDetails? data = null)
        {
            if (data == null)
                return new UnitUpdateResponse { Message = message, Status = status };

            return new UnitUpdateResponse { Message = message, Status = status, unitInfoData = data };
        }
    }
}