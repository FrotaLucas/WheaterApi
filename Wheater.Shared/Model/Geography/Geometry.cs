using System.Text.Json.Serialization;

namespace Wheater.Shared.Model.Geography
{
    public class Geometry
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lng")]
        public double Longitude { get; set; }
    }
}
