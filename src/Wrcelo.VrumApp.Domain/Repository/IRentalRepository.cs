using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Domain.Repository
{
    public interface IRentalRepository
    {
        Task CreateRental(RentalDTO rentalDto);
        Task<Rental> GetRental(Guid rentalGuid);

    }
}
