using System.Text.Json.Serialization;

namespace WheaterApi.Model
{
    public class CityModel
    {
        [JsonPropertyName("geometry")]
       public Geometry Geometry { get; set; }

        [JsonPropertyName("timezone")]
       public Timezone Timezone { get; set; }

    }
}
