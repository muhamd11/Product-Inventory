using System.Text.Json.Serialization;

namespace App.Shared.Models.ColorModule.ViewModel
{
    public class ColorInfoDetails : ColorInfo
    {
        [JsonPropertyOrder(3)]
        public string colorHexCode { get; set; }
    }
}