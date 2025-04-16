using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Domain.Service
{
    public interface IRentalService
    {
        public Task CreateRental(RentalDTO rentalDto);
        public Task<IEnumerable<Rental>> GetAllRentals();
        public Task<Rental> GetRentalById(Guid rentalGuid);
        public Task RentalUpdateEndDate(UpdateEndDateDTO updateEndDateDTO, Guid id);
    }
}
