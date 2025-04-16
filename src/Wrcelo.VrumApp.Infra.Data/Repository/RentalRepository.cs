using Microsoft.EntityFrameworkCore;
using Wrcelo.VrumApp.Core.DTO;
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

        public async Task<Rental> GetRentalById(Guid rentalGuid)
        {
            var rental = await _context.Rentals.FirstOrDefaultAsync(r => r.Guid == rentalGuid);
            if (rental is null)
                throw new Exception("Locação não encontrada");

            return rental;
        }

        public async Task<bool> IsDriverLicenseTypeA(Guid deliveryDriverGuid)
        {
            var deliveryDriver = await _context.DeliveryDrivers.FirstOrDefaultAsync(u => u.Guid == deliveryDriverGuid);

            if (deliveryDriver == null)
            {
                throw new Exception("Entregador não encontrado.");
            }

            return deliveryDriver.DriverLicenseType.Contains("A");
        }

        public async Task<bool> IsMotorcycleAvailable(Guid motorcycleGuid, DateTime startDate, DateTime endDate)
        {
            var rentalConflict = await _context.Rentals
                .AnyAsync(r =>
                    r.MotorcycleGuid == motorcycleGuid &&
                    r.StartDate < endDate &&
                    r.ExpectedEndDate > startDate);

            return !rentalConflict;
        }

        public async Task<IEnumerable<Rental>> GetAllRentals()
        {
            return await _context.Rentals.ToListAsync();
        }

        public async Task UpdateRental(Rental rental)
        {

            _context.Update(rental);
            await _context.SaveChangesAsync();
        }
    }
}
