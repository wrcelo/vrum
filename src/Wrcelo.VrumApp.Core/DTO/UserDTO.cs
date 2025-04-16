using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrcelo.VrumApp.Core.DTO
{
    public class UserDTO
    {
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        public string? Role { get; set; } = "Entregador";
    }
}
