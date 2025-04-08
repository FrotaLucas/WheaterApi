using System.Text.Json.Serialization;

namespace Wheater.Shared.Model.Geography
{
    public class GeographyData
    {
        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }

        [JsonPropertyName("annotations")]
        public Annotations Annotations { get; set; }

    }
}
