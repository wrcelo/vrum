using Microsoft.AspNetCore.Mvc;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Service;

namespace Wrcelo.VrumApp.API.Controllers
{
    [Route("api/rentals")]
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
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRentalById(Guid id)
        {
            try
            {
                return Ok(await _rentalService.GetRentalById(id));
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRentals()
        {
            try
            {
                return Ok(await _rentalService.GetAllRentals());
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut]
        [Route("{id}/devolution")]
        public async Task<IActionResult> MotorcycleReturn([FromBody] UpdateEndDateDTO dateDto, Guid id)
        {
            try
            {
                await _rentalService.RentalUpdateEndDate(dateDto, id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

    }
}
