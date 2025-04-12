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


        public async Task<bool> CreateMotorcycle(MotorcycleDTO motorcycleDto)
        {
            try
            {
                var result = Motorcycle.Create(motorcycleDto.Year, motorcycleDto.Model, motorcycleDto.LicensePlate);

                if (result.IsFailure)
                {

                }


                return await _motorcycleRepository.CreateMotorcycle(motorcycleDto);
            }
            catch (Exception)
            {
                throw;
            }


        }

        public Task DeleteMotorcycle(int motorcycleId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditMotorcycleLicensePlate(int motorcycleId, EditMotorcycleDTO editMotorcycleDTO)
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

                var result = await _motorcycleRepository.EditMotorcycleLicensePlate(motorcycleId, editMotorcycleDTO);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Motorcycle> GetMotorcycleByGuid(int motorcycleId)
        {
            throw new NotImplementedException();
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
