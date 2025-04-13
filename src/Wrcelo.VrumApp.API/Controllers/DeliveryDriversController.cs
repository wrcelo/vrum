using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Core.Response;

namespace Wrcelo.VrumApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryDriversController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateDeliveryDriver(DeliveryDriverDTO deliveryDriverDTO)
        {
            try
            {
                return Created();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        } 
    }
}
