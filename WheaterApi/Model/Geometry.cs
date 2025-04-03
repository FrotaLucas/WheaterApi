using System.Text.Json.Serialization;

namespace WheaterApi.Model
{
    public class Geometry
    {
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; } = string.Empty;

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; } = string.Empty;
    }
}
