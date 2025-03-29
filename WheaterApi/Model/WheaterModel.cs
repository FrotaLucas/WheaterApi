using System.Text.Json.Serialization;

namespace WheaterApi.Model
{
    public class WheaterModel
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [JsonPropertyName("timezone")]
        public string TimeZone { get; set; } = string.Empty;

        [JsonPropertyName("hourly")]
        public WheaterDataModel TemperatureDate { get; set; } 




    }
}
