using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrcelo.VrumApp.Domain.Entity
{
    public class DeliveryDriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; } 
        public DateTime BirthDate { get; set; }
        public string DriverLicenseNumber { get; set; } 
        public string DriverLicenseType { get; set; } 
        public string DriverLicenseImagePath { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }
}
