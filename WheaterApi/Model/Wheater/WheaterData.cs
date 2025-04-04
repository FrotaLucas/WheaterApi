using System.Text.Json.Serialization;

namespace WheaterApi.Model.Wheater
{
    public class WheaterData
    {
        public List<string> Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<double> Temperature { get; set; }

    }
}
