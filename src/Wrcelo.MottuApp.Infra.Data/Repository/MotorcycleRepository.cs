using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;
using Wrcelo.VrumApp.Domain.Repository;

namespace Wrcelo.VrumApp.Application.Services
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        public Task<bool> CreateMotorcycle(MotorcycleDTO motorcycleDto)
        {
            //Trabalhar com entity
            throw new NotImplementedException();
        }

        public Task DeleteMotorcycle(int motorcycleId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditMotorcycleLicensePlate(int motorcycleId, EditMotorcycleDTO editMotorcycleDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Motorcycle> GetMotorcycleByGuid(int motorcycleId)
        {
            throw new NotImplementedException();
        }

        Task<Motorcycle> IMotorcycleRepository.GetMotorcycleByLicensePlate(string licensePlate)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Motorcycle>> IMotorcycleRepository.GetMotorcycles()
        {
            throw new NotImplementedException();
        }
    }
}
