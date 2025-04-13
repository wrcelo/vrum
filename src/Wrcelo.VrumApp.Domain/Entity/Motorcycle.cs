using Wrcelo.VrumApp.Core.Shared;

namespace Wrcelo.VrumApp.Domain.Entity
{
    public class Motorcycle
    {

        private Motorcycle(int year, string model, string licensePlate)
        {
            Year = year;
            Model = model;
            LicensePlate = licensePlate;
        }

        public Guid Guid { get; private set; }
        public int Year { get; private set; }
        public string Model { get; private set; }
        public string LicensePlate { get; private set; }
        public ICollection<Rental> Rentals { get; private set; } = new List<Rental>();


        public static Result<Motorcycle> Create(int year, string model, string licensePlate)
        {
            var errors = new List<string>();


            if (year <= 0)
                errors.Add("Invalid year.");

            if (string.IsNullOrWhiteSpace(model))
                errors.Add("Model is required.");

            if (string.IsNullOrWhiteSpace(licensePlate))
                errors.Add("License plate is required.");

            if(!LicensePlateValidator.IsValid(licensePlate))
                errors.Add("License plate format is invalid.");

            if (errors.Count > 0)
                return Result<Motorcycle>.Failure(errors);

            var motorcycle = new Motorcycle(year, model, licensePlate);
            return Result<Motorcycle>.Success(motorcycle);
        }

        public void UpdateLicensePlate(string newLicensePlate)
        {
            if (string.IsNullOrWhiteSpace(newLicensePlate))
                throw new ArgumentException("License plate cannot be empty.");

            LicensePlate = newLicensePlate;
        }

    }
}
