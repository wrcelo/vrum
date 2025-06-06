﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Service;

namespace Wrcelo.VrumApp.API.Controllers
{

    [Authorize(Roles = "Admin")]
    [Route("api/motorcycles")]
    [ApiController]
    public class MotorcyclesController : ControllerBase
    {
        private readonly IMotorcycleService _motorcycleService;
        public MotorcyclesController(IMotorcycleService motorcycleService)
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
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetMotorcycle([FromQuery] string? licensePlate)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(licensePlate))
                {
                    return Ok(await _motorcycleService.GetMotorcycles());
                }

                return Ok(await _motorcycleService.GetMotorcycleByLicensePlate(licensePlate));

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch]
        [Route("{id}/license-plate")]
        public async Task<IActionResult> EditMotorcycleLicensePlate([FromBody] EditMotorcycleDTO editMotorcycleDTO, Guid id)
        {
            try
            {
                await _motorcycleService.EditMotorcycleLicensePlate(id, editMotorcycleDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMotorcycleByGuid(Guid id)
        {
            try
            {
                var motorcycle = await _motorcycleService.GetMotorcycleByGuid(id);

                if (motorcycle == null)
                    return NotFound();


                return Ok(motorcycle);
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });

            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMotorcycleById(Guid id)
        {
            try
            {
                await _motorcycleService.DeleteMotorcycle(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

    }
}
