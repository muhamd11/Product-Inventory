using System.Text.Json.Serialization;

namespace App.Shared.Models.AdditionsModules.Shared.Units.ViewModel
{
    public class UnitInfoDetails : UnitInfo
    {
        [JsonPropertyOrder(4)]
        public string unitDescription { get; set; }
    }
}