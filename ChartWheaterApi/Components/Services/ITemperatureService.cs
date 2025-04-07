using WheaterApi.Model.Wheater;

namespace ChartWheaterApi.Components.Services
{
    public interface ITemperatureService
    {
        Task UpdateApi(string city = "Berlin");
        Task<ResponseWheater> getTemp(string city);

        event Action TemperatureChanged;
        ResponseWheater Data { get; set; }
        
    }
}
