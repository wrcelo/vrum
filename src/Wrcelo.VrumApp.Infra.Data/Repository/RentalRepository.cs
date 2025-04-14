using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;
using Wrcelo.VrumApp.Domain.Repository;

namespace Wrcelo.VrumApp.Infra.Data.Repository
{
    public class RentalRepository : IRentalRepository
    {
        public Task CreateRental(RentalDTO rentalDto)
        {
            throw new NotImplementedException();
        }

        public Task<Rental> GetRental(Guid rentalGuid)
        {
            throw new NotImplementedException();
        }

    }
}
