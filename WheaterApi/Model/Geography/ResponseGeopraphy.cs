using System.Text.Json.Serialization;

namespace WheaterApi.Model.Geography
{
    public class ResponseGeopraphy
    {
        [JsonPropertyName("results")]
        public List<GeographyData> results { get; set; }

    }
}
