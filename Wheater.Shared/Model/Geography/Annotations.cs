using System.Text.Json.Serialization;

namespace Wheater.Shared.Model.Geography
{
    public class Annotations
    {
        [JsonPropertyName("timezone")]
        public Timezone Timezone { get; set; }
    }
}
