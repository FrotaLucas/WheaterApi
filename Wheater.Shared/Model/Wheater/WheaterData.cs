using System.Text.Json.Serialization;

namespace Wheater.Shared.Model.Wheater
{
    public class WheaterData
    {
        public List<string> Time { get; set; }


        [JsonPropertyName("temperature_2m")]

        public List<double> Temperatures { get; set; }


        [JsonPropertyName("precipitation_probability")]
        
        public List<double> Precipitations { get; set; }





    }
}
