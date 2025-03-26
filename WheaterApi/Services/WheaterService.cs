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

        public async Task<WheaterModel> getWheaterData(double latitude, double longitude)
        {
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true";

            string cacheKey = $"{latitude}-{longitude}";
            var cacheData = await _cache.GetStringAsync(cacheKey) ;

            if(!string.IsNullOrEmpty(cacheData))
            {
                //transform Byte data format into json ?
                var json = JsonSerializer.Deserialize<WheaterModel>(cacheData) ;
                return json;
            }

            var responseApi = await _httpClient.GetFromJsonAsync<WheaterModel>(url);

            //set cache for 10 min
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

            _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(responseApi), options);

            return new WheaterModel
            {
                Latitude = responseApi.Latitude,
                Longitude = responseApi.Longitude
            };


        }
    }
}
