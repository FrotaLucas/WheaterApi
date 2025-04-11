using System.Net.Http.Json;
using Wheater.Shared.Model.Chart;
using Wheater.Shared.Model.Wheater;

namespace ChartWheaterApi.Services
{
    public class WheaterService : IWheaterService
    {
        private readonly HttpClient _httpClient;
        public WheaterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public ResponseWheater Data { get; set; } = new ResponseWheater();
        
        public List<ChartTemperatureData> chartTemperatureData { get; set; } =  new List<ChartTemperatureData>();

        public List<ChartPrecipitationData> chartPrecipitationData { get; set; } = new List<ChartPrecipitationData>();

        public Double minTemp { get; set; } = 0;

        public event Action TemperatureChanged;

        public async Task<ResponseWheater> getTemp(string city)
        {
            
            var result = await _httpClient.GetFromJsonAsync<ResponseWheater>($"api/Wheater?city={city}");
           
            Data = result;

            chartTemperatureData.Clear();

            chartPrecipitationData.Clear();

            if (result != null)
            {
                for (int i = 0; i < result.WheaterData.Temperatures.Count(); i++) 
                {
                    var data = new ChartTemperatureData()
                    {
                        Temps = result.WheaterData.Temperatures[i],
                        Time = result.WheaterData.Time[i].Split("T")[1]
                    };

                    if(data.Temps < minTemp)
                        minTemp = data.Temps;

                    chartTemperatureData.Add(data);
                }

                for (int i = 0; i < result.WheaterData.Precipitations.Count(); i++)
                {
                    var data = new ChartPrecipitationData()
                    {
                        Precipitation = result.WheaterData.Precipitations[i],
                        Time = result.WheaterData.Time[i].Split("T")[1]
                    };
                    chartPrecipitationData.Add(data);
                }
            }


            Data = result;

            return result;
        }

        public async Task UpdateApi(string city)
        {
            var result = await getTemp(city);

            TemperatureChanged.Invoke();
        }

    }
}
