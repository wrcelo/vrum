using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Domain.Repository
{
    public interface IRentalRepository
    {
        public Task CreateRental(Rental rental);
        public Task<Rental> GetRental(Guid rentalGuid);
        public Task<bool> IsDriverLicenseTypeA(Guid deliveryDriverGuid);
        public Task<bool> IsMotorcycleAvailable(Guid motorcycleGuid, DateTime startDate, DateTime endDate);
    }
}
