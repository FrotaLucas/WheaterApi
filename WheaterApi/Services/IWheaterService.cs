using WheaterApi.Model.Geography;
using WheaterApi.Model.Wheater;

namespace WheaterApi.Services
{
    public interface IWheaterService
    {
        public Task<ResponseGeopraphy> getLatitudeAndLongitude(string city);

        Task<ResponseWheater> getTemperatureData(string city);
    }
}
