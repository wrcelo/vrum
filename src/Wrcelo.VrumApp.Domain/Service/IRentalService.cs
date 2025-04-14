using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Domain.Service
{
    public interface IRentalService
    {
        Task CreateRental(RentalDTO rentalDto);
        Task<Rental> GetRental(Guid rentalGuid);

    }
}
