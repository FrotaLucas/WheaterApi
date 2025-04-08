using System.Text.Json.Serialization;

namespace Wheater.Shared.Model.Geography
{
    public class Timezone
    {
        [JsonPropertyName("name")]
        public string name { get; set; } = string.Empty;
    }
}
