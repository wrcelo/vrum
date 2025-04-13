using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Domain.Repository
{
    public interface IMotorcycleRepository
    {
        Task CreateMotorcycle(Motorcycle motorcycle);
        Task<IEnumerable<Motorcycle>> GetMotorcycles();
        Task<Motorcycle> GetMotorcycleByLicensePlate(string licensePlate);
        Task EditMotorcycleLicensePlate(Guid id, EditMotorcycleDTO editMotorcycleDTO);
        Task<Motorcycle> GetMotorcycleByGuid(Guid id);
        Task DeleteMotorcycle(Guid id);
        Task<bool> IsMotorcycleReadyToDelete(Guid id);
    }
}
