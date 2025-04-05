using WheaterApi.Model.Wheater;

namespace ChartWheaterApi.Components.Services
{
    public class TemperatureService : ITemperatureService
    {
        public TemperatureService() { }

        public async Task<ResponseWheater> getTemperature()
        {


            return new ResponseWheater()
            {
                Latitude = 0,
                Longitude = 0,
                TimeZone = "America",
                TemperatureDate = new WheaterData()
                {
                    Temperature = [25,23,29,4,23,23]
                }
            };
        }
    }
}
