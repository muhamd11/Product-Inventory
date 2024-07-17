using App.Shared.Consts.SystemBase;
using System.Text.Json.Serialization;

namespace Api.Controllers.SystemBase._01._2_SystemRoleFincations
{
    public class SystemRoleFincation
    {
        [JsonIgnore] public int id { get; set; }
        [JsonIgnore] public int systemRoleId { get; set; }
        public EnumFuncationsType funcationsType { get; set; }
        public string moduleId { get; set; }
        public string funcationId { get; set; }
        public bool isHavePrivlage { get; set; }
    }
}