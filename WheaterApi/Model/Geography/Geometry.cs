using System.Text.Json.Serialization;

namespace WheaterApi.Model.Geography
{
    public class Geometry
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lng")]
        public double Longitude { get; set; }
    }
}
