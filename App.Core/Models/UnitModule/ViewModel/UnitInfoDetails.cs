using System.Text.Json.Serialization;

namespace App.Shared.Models.UnitModule.ViewModel
{
    public class UnitInfoDetails : UnitInfo
    {
        [JsonPropertyOrder(3)]
        public string unitDescription { get; set; }
    }
}