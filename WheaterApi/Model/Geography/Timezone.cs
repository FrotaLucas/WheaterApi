using System.Text.Json.Serialization;

namespace WheaterApi.Model.Geography
{
    public class Timezone
    {
        [JsonPropertyName("name")]
        public string name { get; set; } = string.Empty;
    }
}
