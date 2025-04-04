using System.Text.Json.Serialization;

namespace WheaterApi.Model.Geography
{
    public class GeographyData
    {
        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }

        [JsonPropertyName("annotations")]
        public Annotations Annotations { get; set; }

    }
}
