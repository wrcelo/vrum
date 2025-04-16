using Microsoft.EntityFrameworkCore;
using Wrcelo.VrumApp.Domain.Entity;
using Wrcelo.VrumApp.Domain.Repository;
using Wrcelo.VrumApp.Infra.Data.Context;

namespace Wrcelo.VrumApp.Infra.Data.Repository
{
    public class DeliveryDriverRepository : IDeliveryDriverRepository
    {
        private readonly ApiContext _context;
        public DeliveryDriverRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task CreateDeliveryDriver(DeliveryDriver deliveryDriver, Guid userGuid)
        {
            deliveryDriver.UserGuid = userGuid;
            await _context.DeliveryDrivers.AddAsync(deliveryDriver);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDriverLicenseImage(string base64ImageString)
        {
            return;
        }

        public async Task<IEnumerable<DeliveryDriver>> GetAllDeliveryDrivers()
        {

            return await _context.DeliveryDrivers.ToListAsync();

        }

        public async Task<DeliveryDriver> GetDeliveryDriverById(Guid id)
        {
            return await _context.DeliveryDrivers.FirstOrDefaultAsync(dd => dd.Guid == id);
        }
    }
}
