using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Service;

namespace Wrcelo.VrumApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRental(RentalDTO rentalDto)
        {
            try
            {
                await _rentalService.CreateRental(rentalDto);
                return Created();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
