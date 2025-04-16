using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Wrcelo.VrumApp.Core.DTO
{
    public class DeliveryDriverDTO : UserDTO
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime BirthDate { get; set; }
        public string DriverLicenseNumber { get; set; }
        public string DriverLicenseType { get; set; }
        public string DriverLicenseImageBase64 { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string Role { get; set; }


    }
}
