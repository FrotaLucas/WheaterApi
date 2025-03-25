using System.Text.Json;
using WheaterApi.Model;

namespace WheaterApi.Services
{
    public class WheaterService
    {
        private readonly HttpClient _httpClient;
        public WheaterService(HttpClient httpClient)
        {
            _httpClient = httpClient;   
        }

        public async Task<WheaterModel> getWheaterData(double latitude, double longitude)
        {
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true";

            var data = await _httpClient.GetFromJsonAsync<WheaterModel>(url);

            return new WheaterModel
            {

                Latitude = data.Latitude,
                Longitude = data.Longitude
            };


        }
    }
}
