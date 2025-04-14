using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Domain.Repository
{
    public interface IMotorcycleRepository
    {
        Task CreateMotorcycle(Motorcycle motorcycle);
        Task<IEnumerable<Motorcycle>> GetMotorcycles();
        Task<Motorcycle> GetMotorcycleByLicensePlate(string licensePlate);
        Task EditMotorcycleLicensePlate(Guid guid, EditMotorcycleDTO editMotorcycleDTO);
        Task<Motorcycle> GetMotorcycleByGuid(Guid guid);
        Task DeleteMotorcycle(Guid guid);
        Task<bool> IsMotorcycleReadyToDelete(Guid guid);
    }
}
