using Microsoft.AspNetCore.Mvc;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Service;

namespace Wrcelo.VrumApp.API.Controllers
{


    [Route("api/delivery-drivers")]
    [ApiController]
    public class DeliveryDriversController : ControllerBase
    {
        private readonly IDeliveryDriverService _deliveryDriverService;

        public DeliveryDriversController(IDeliveryDriverService deliveryDriverService)
        {
            _deliveryDriverService = deliveryDriverService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeliveryDriver(DeliveryDriverDTO deliveryDriverDTO)
        {
            try
            {
                await _deliveryDriverService.CreateDeliveryDriver(deliveryDriverDTO);
                return Created();
            }
            catch (Exception)
            {
                return BadRequest(new {mensagem = "Dados inválidos"});
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDeliveryDrivers()
        {
            try
            {
                return Ok(await _deliveryDriverService.GetAllDeliveryDrivers());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("{id}/license")]
        public async Task<IActionResult> PostLicenseImage([FromBody] LicenseImageBase64StringDTO licenseImageDto, Guid id)
        {
            try
            {
                await _deliveryDriverService.UpdateLicenseImage(id, licenseImageDto.LicensePhotoBase64String);
                return Created();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = $"Dados inválidos: {ex.Message}" });
            }
        }


    }
}
