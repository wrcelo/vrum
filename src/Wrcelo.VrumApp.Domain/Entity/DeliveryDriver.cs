using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wrcelo.VrumApp.Core.Shared;

namespace Wrcelo.VrumApp.Domain.Entity
{
    public class DeliveryDriver
    {
        public DeliveryDriver(string name, string cnpj, DateTime birthDate, string driverLicenseNumber, string driverLicenseType, string? driverLicenseImagePath)
        {
            Name = name;
            Cnpj = cnpj;
            BirthDate = birthDate;
            DriverLicenseNumber = driverLicenseNumber;
            DriverLicenseType = driverLicenseType;
            DriverLicenseImagePath = driverLicenseImagePath;
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; } 
        public DateTime BirthDate { get; set; }
        public string DriverLicenseNumber { get; set; } 
        public string DriverLicenseType { get; set; } 
        public string DriverLicenseImagePath { get; set; }
        public Guid UserGuid { get; set; }
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();


        public static Result<DeliveryDriver> Create(string name, string cnpj, DateTime birthDate, string driverLicenseNumber, string driverLicenseType, string? driverLicenseImagePath)
        {
            var errors = new List<string>();
            

            if (string.IsNullOrWhiteSpace(name))
                errors.Add("O nome deve ser preenchido.");

            if (string.IsNullOrWhiteSpace(cnpj))
                errors.Add("CNPJ deve ser preenchido.");

            if(birthDate > DateTime.UtcNow.AddYears(-18))
                errors.Add("Entregador deve ser maior de 18 anos.");

            if (string.IsNullOrWhiteSpace(driverLicenseNumber))
                errors.Add("CNH deve ser preenchido.");

            if (string.IsNullOrWhiteSpace(driverLicenseType))
                errors.Add("Tipo da CNH deve ser preenchido");

            if (driverLicenseType != "A" && driverLicenseType != "B" && driverLicenseType != "AB")
                errors.Add("Tipo da CNH deve ser 'A', 'B' ou 'A+B'");



            if (errors.Count > 0)
                return Result<DeliveryDriver>.Failure(errors);

            var deliveryDriver = new DeliveryDriver(name, cnpj, birthDate, driverLicenseNumber, driverLicenseType, driverLicenseImagePath);
            return Result<DeliveryDriver>.Success(deliveryDriver);
        }
    }
}
