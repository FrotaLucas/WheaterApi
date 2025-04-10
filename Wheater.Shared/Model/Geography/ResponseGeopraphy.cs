using System.Text.Json.Serialization;

namespace Wheater.Shared.Model.Geography
{
    public class ResponseGeopraphy
    {
        [JsonPropertyName("results")]
        public List<GeographyData> Results { get; set; }

    }
}
