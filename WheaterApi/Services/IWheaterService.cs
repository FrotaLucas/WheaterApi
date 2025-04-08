using Wheater.Shared.Model.Wheater;
using Wheater.Shared.Model.Geography;

namespace WheaterApi.Services
{
    public interface IWheaterService
    {
        public Task<ResponseGeopraphy> getLatitudeAndLongitude(string city);

        Task<ResponseWheater> getTemperatureData(string city);
    }
}
