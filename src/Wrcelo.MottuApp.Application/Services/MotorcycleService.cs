using System.Text.Json;
using System.Xml.Linq;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Core.Shared;
using Wrcelo.VrumApp.Domain.Entity;
using Wrcelo.VrumApp.Domain.Repository;
using Wrcelo.VrumApp.Domain.Service;

namespace Wrcelo.VrumApp.Application.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public MotorcycleService(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }


        public async Task CreateMotorcycle(MotorcycleDTO motorcycleDto)
        {
            try
            {
                var motorcycle = Motorcycle.Create(motorcycleDto.Year, motorcycleDto.Model, motorcycleDto.LicensePlate);

                if (motorcycle.IsFailure)
                {
                    throw new Exception(JsonSerializer.Serialize(motorcycle.Errors));
                }

                await _motorcycleRepository.CreateMotorcycle(motorcycle.Value);
            }
            catch (Exception)
            {
                throw;
            }


        }

        public async Task DeleteMotorcycle(Guid id)
        {
            await _motorcycleRepository.DeleteMotorcycle(id);
        }

        public async Task EditMotorcycleLicensePlate(Guid id, EditMotorcycleDTO editMotorcycleDTO)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(editMotorcycleDTO.LicensePlate))
                {
                    throw new Exception("License plate cannot be empty.");
                }

                if (!LicensePlateValidator.IsValid(editMotorcycleDTO.LicensePlate))
                {
                    throw new Exception("License plate format is invalid.");
                }

                await _motorcycleRepository.EditMotorcycleLicensePlate(id, editMotorcycleDTO);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Motorcycle> GetMotorcycleByGuid(Guid id)
        {
            try
            {
                var motorcycle = await _motorcycleRepository.GetMotorcycleByGuid(id);

                return motorcycle;
            }
            catch (Exception)
            {
                throw;

            }
        }

        public async Task<IEnumerable<Motorcycle>> GetMotorcycles()
        {
            try
            {
                var motorcycles = await _motorcycleRepository.GetMotorcycles();

                return motorcycles;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<Motorcycle> GetMotorcycleByLicensePlate(string licensePlate)
        {
            try
            {
                var motorcycle = await _motorcycleRepository.GetMotorcycleByLicensePlate(licensePlate);
                return motorcycle;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
