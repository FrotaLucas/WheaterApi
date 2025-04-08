using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Web;
using Wheater.Shared.Model.Wheater;
using Wheater.Shared.Model.Geography;

namespace WheaterApi.Services
{
    public class WheaterService : IWheaterService
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

        public async Task<ResponseGeopraphy> getLatitudeAndLongitude(string city)
        {
            //remove any simbol or circumflex accent but brings erros from api response
            //city = HttpUtility.UrlDecode(city.Trim().ToLower().Replace(" ", ""));
            city = city.Trim().ToLower();

            string uri = $"https://api.opencagedata.com/geocode/v1/json?q={city}&key=42100b764202470b9a1ca4db79301088";
            var response = await _httpClient.GetFromJsonAsync<ResponseGeopraphy>(uri);

            return response;
        }
            
        public async Task<ResponseWheater> getTemperatureData(string city)
        {
            string latitude = string.Empty;
            string longitude = string.Empty;
            string continent = string.Empty;
            string cityReference = string.Empty;
            string timeZone = string.Empty;
            GeographyData geographyData = null;

            var response = await getLatitudeAndLongitude(city);

            if( response.results != null && response.results.Count > 0)
            {
                geographyData = response.results[0];
            }


            timeZone = geographyData.Annotations.Timezone.name;
            continent = timeZone.Split("/")[0];
            cityReference = timeZone.Split("/").Last();
            latitude = geographyData.Geometry.Latitude.ToString();
            longitude = geographyData.Geometry.Longitude.ToString();



            string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&hourly=temperature_2m&timezone={continent}%2F{cityReference}&forecast_days=1";
            //"https://api.open-meteo.com/v1/forecast?latitude=48.1374&longitude=11.5755&hourly=temperature_2m&timezone=Europe%2FBerlin&forecast_days=1"

            string cacheKey = $"{latitude}-{longitude}";
            //var cacheData = await _cache.GetStringAsync(cacheKey) ;

            //if(!string.IsNullOrEmpty(cacheData))
            //{
            //    //transform Byte data format into json ?
            //    var json = JsonSerializer.Deserialize<WheaterModel>(cacheData) ;
            //    return json;
            //}

            var responseApi = await _httpClient.GetFromJsonAsync<ResponseWheater>(url);

            //set cache for 10 min
            //var options = new DistributedCacheEntryOptions()
            //    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

            //_cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(responseApi), options);

            return new ResponseWheater
            {
                Latitude = responseApi.Latitude,
                Longitude = responseApi.Longitude,
                TimeZone = responseApi.TimeZone,
                TemperatureDate = responseApi.TemperatureDate,
                
            };


        }
    }
}
