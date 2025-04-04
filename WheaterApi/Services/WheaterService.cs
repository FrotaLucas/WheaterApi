using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using WheaterApi.Model;

namespace WheaterApi.Services
{
    public class WheaterService
    {
        private readonly HttpClient _httpClient;
        private readonly IDistributedCache _cache;
        public WheaterService(HttpClient httpClient, IDistributedCache cache)
        {
            _httpClient = httpClient;   
            _cache = cache;
        }

        //api opencage data
        //latitude e longitude 
        //https://api.opencagedata.com/geocode/v1/json?q=-22%2C+-43&key=42100b764202470b9a1ca4db79301088

        //Forward Geocoding
        //city name
        //https://api.opencagedata.com/geocode/v1/json?q=RioDeJaneiro&key=42100b764202470b9a1ca4db79301088

        public async Task<ResponseData> getLatitudeAndLongitude(string city)
        {
            //city  = "https://api.opencagedata.com/geocode/v1/json?q=RioDeJaneiro&key=42100b764202470b9a1ca4db79301088";
            string uri = $"https://api.opencagedata.com/geocode/v1/json?q={city}&key=42100b764202470b9a1ca4db79301088";
            var response = await _httpClient.GetFromJsonAsync<ResponseData>(uri);

            return response;
        }
            
        public async Task<WheaterModel> getTemperatureData(string timezone)
        {
            string latitude = string.Empty;
            string longitude = string.Empty;
            
            var response = await getLatitudeAndLongitude(timezone);

            if (response != null || response.results != null) {
                foreach (var item in response.results)
                {
                    latitude = item.Geometry.Latitude.ToString();
                    longitude = item.Geometry.Longitude.ToString();

                    Console.WriteLine($"Latitude: {latitude}, Longitude: {longitude}");
                }
            }


            string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&hourly=temperature_2m&timezone=Europe%2F{timezone}&forecast_days=1";
            //"https://api.open-meteo.com/v1/forecast?latitude=48.1374&longitude=11.5755&hourly=temperature_2m&timezone=Europe%2FBerlin&forecast_days=1"

            string cacheKey = $"{latitude}-{longitude}";
            //var cacheData = await _cache.GetStringAsync(cacheKey) ;

            //if(!string.IsNullOrEmpty(cacheData))
            //{
            //    //transform Byte data format into json ?
            //    var json = JsonSerializer.Deserialize<WheaterModel>(cacheData) ;
            //    return json;
            //}

            var responseApi = await _httpClient.GetFromJsonAsync<WheaterModel>(url);

            //set cache for 10 min
            //var options = new DistributedCacheEntryOptions()
            //    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

            //_cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(responseApi), options);

            return new WheaterModel
            {
                Latitude = responseApi.Latitude,
                Longitude = responseApi.Longitude,
                TimeZone = responseApi.TimeZone,
                TemperatureDate = responseApi.TemperatureDate,
                
            };


        }
    }
}
