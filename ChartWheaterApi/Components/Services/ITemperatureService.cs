using WheaterApi.Model.Wheater;

namespace ChartWheaterApi.Components.Services
{
    public interface ITemperatureService
    {
        Task<ResponseWheater> getTemperature();
        
    }
}
