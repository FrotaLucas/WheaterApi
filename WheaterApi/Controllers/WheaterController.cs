using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WheaterApi.Services;

namespace WheaterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WheaterController : ControllerBase
    {
        private readonly WheaterService _wheaterService;
        public WheaterController(WheaterService wheaterService)
        {
            _wheaterService = wheaterService;
        }

        [HttpGet]
        public async Task<IActionResult> getWheaterData([FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] string timeZone )
        {
            var response = await _wheaterService.getWheaterData(latitude, longitude, timeZone);
            
            if (response == null) { 
                return NotFound("Data not found");
            }

            return Ok(response);
        }
    }
}
