using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WheaterApi.Services;

namespace WheaterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WheaterController : ControllerBase
    {
        private readonly IWheaterService _wheaterService;
        public WheaterController(IWheaterService wheaterService)
        {
            _wheaterService = wheaterService;
        }

        //route http://localhost:5000/api/Wheater?city=Berlin

        [HttpGet]
        public async Task<IActionResult> getWheaterData([FromQuery] string city )
        {
            var response = await _wheaterService.getTemperatureData(city);
            
            if (response == null) { 
                return NotFound("Data not found");
            }

            return Ok(response);
        }
    }
}
