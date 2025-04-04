using System.Text.Json.Serialization;

namespace WheaterApi.Model.Geography
{
    public class Annotations
    {
        [JsonPropertyName("timezone")]
        public Timezone Timezone { get; set; }
    }
}
