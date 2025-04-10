using Wheater.Shared.Model.Chart;
using Wheater.Shared.Model.Wheater;

namespace ChartWheaterApi.Services
{
    public interface ITemperatureService
    {
        Task UpdateApi(string city = "Berlin");
        
        Task<ResponseWheater> getTemp(string city);

        event Action TemperatureChanged;
        
        ResponseWheater Data { get; set; }

        ChartData chartData { get; set; }

    }
}
