using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Domain.Repository
{
    public interface IRentalRepository
    {
        public Task CreateRental(Rental rental);
        public Task<Rental> GetRentalById(Guid rentalGuid);
        public Task<IEnumerable<Rental>> GetAllRentals();
        public Task<bool> IsDriverLicenseTypeA(Guid deliveryDriverGuid);
        public Task<bool> IsMotorcycleAvailable(Guid motorcycleGuid, DateTime startDate, DateTime endDate);
        public Task UpdateRental(Rental rental);
    }
}
