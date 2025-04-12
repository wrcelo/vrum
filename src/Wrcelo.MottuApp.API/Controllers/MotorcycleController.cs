using Microsoft.AspNetCore.Mvc;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Core.Shared;
using Wrcelo.VrumApp.Domain.Service;

namespace Wrcelo.VrumApp.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class MotorcycleController : ControllerBase
    {
        private readonly IMotorcycleService _motorcycleService;
        public MotorcycleController(IMotorcycleService motorcycleService)
        {
            _motorcycleService = motorcycleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMotorcycle([FromBody] MotorcycleDTO motorcycleDto)
        {
            try
            {
                await _motorcycleService.CreateMotorcycle(motorcycleDto);
                return Created();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetMotorcycle([FromQuery] string? licensePlate)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(licensePlate))
                {
                    var motorcycles = await _motorcycleService.GetMotorcycles();
                    return Ok(motorcycles);
                }

                var motorcycle = await _motorcycleService.GetMotorcycleByLicensePlate(licensePlate);
                return Ok(motorcycle);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch]
        [Route("{id}/license-plate")]
        public async Task<IActionResult> EditMotorcycleLicensePlate([FromBody] EditMotorcycleDTO editMotorcycleDTO, int id)
        {
            try
            {
                var result = await _motorcycleService.EditMotorcycleLicensePlate(id, editMotorcycleDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
