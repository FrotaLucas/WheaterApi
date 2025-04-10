using System.Net.Http.Json;
using Wheater.Shared.Model.Chart;
using Wheater.Shared.Model.Wheater;

namespace ChartWheaterApi.Services
{
    public class TemperatureService : ITemperatureService
    {
        private readonly HttpClient _httpClient;
        public TemperatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public ResponseWheater Data { get; set; } = new ResponseWheater();
        
        public List<ChartTemperatureData> chartTemperatureData { get; set; } =  new List<ChartTemperatureData>();


        public event Action TemperatureChanged;

        public async Task<ResponseWheater> getTemp(string city)
        {
            
            var result = await _httpClient.GetFromJsonAsync<ResponseWheater>($"api/Wheater?city={city}");
            //http://localhost:5000/api/Wheater?city=coroaci

            Data = result;

            chartTemperatureData.Clear();

            if (result != null)
            {
                for (int i = 0; i < result.WheaterData.Temperatures.Count(); i++) 
                {
                    var data = new ChartTemperatureData()
                    {
                        Temps = result.WheaterData.Temperatures[i],
                        Time = result.WheaterData.Time[i].Split("T")[1]
                    };
                    chartTemperatureData.Add(data);
                }
            }


            //Data = result;

            return result;//talvez nao preciso restornar result, pq a atualizacao dos dados eh feito pelo Evento no DOM
        }
        public async Task UpdateApi(string city)
        {
            var result = await getTemp(city);

            //var response = new ResponseWheater()
            //{
            //    Latitude = result.Latitude,
            //    Longitude = result.Longitude,
            //    TimeZone = result.TimeZone,
            //    TemperatureDate = result.TemperatureDate,
            //    //TemperatureDate = new WheaterData()
            //    //{
            //    //    Temperature = [25,23,29,4,23,23]
            //    //}
            //};

            TemperatureChanged.Invoke();
        }

    }
}
