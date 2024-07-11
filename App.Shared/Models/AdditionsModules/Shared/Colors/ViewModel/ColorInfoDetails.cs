using System.Text.Json.Serialization;

namespace App.Shared.Models.AdditionsModules.Shared.Colors.ViewModel
{
    public class ColorInfoDetails : ColorInfo
    {
        [JsonPropertyOrder(3)]
        public string colorDescription { get; set; }

        [JsonPropertyOrder(4)]
        public string colorHexCode { get; set; }
    }
}