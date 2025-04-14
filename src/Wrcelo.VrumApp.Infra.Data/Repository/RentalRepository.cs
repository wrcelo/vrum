using Microsoft.EntityFrameworkCore;
using Wrcelo.VrumApp.Domain.Entity;
using Wrcelo.VrumApp.Domain.Repository;
using Wrcelo.VrumApp.Infra.Data.Context;

namespace Wrcelo.VrumApp.Infra.Data.Repository
{
    public class RentalRepository : IRentalRepository
    {
        private readonly ApiContext _context;
        public RentalRepository(ApiContext context)
        {
            _context = context;
        }
        public async Task CreateRental(Rental rental)
        {
            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();
        }

        public async Task<Rental> GetRental(Guid rentalGuid)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsDriverLicenseTypeA(Guid deliveryDriverGuid)
        {
            var deliveryDriver = await _context.DeliveryDrivers.FirstAsync(u => u.Guid == deliveryDriverGuid);

            if (deliveryDriver == null)
            {
                throw new Exception("Entregador não encontrado.");
            }

            return deliveryDriver.DriverLicenseType.Contains("A");
        }

        public async Task<bool> IsMotorcycleAvailable(Guid motorcycleGuid, DateTime startDate, DateTime endDate)
        {
            var rental = _context.Rentals.Where(r => motorcycleGuid ==  r.MotorcycleGuid && startDate >= r.StartDate || endDate >= r.ExpectedEndDate);
            return !rental.Any();
        }
    }
}
