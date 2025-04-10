using System.Text.Json.Serialization;

namespace Wheater.Shared.Model.Wheater
{
    public class ResponseWheater
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [JsonPropertyName("timezone")]
        public string TimeZone { get; set; } = string.Empty;

        [JsonPropertyName("hourly")]
        public WheaterData WheaterData { get; set; } = new WheaterData();


    }
}
