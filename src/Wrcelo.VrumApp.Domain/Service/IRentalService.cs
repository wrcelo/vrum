using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Domain.Service
{
    public interface IRentalService
    {
        public Task CreateRental(RentalDTO rentalDto);
        public Task<Rental> GetRental(Guid rentalGuid);

    }
}
