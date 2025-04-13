using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrcelo.VrumApp.Domain.Entity;

namespace Wrcelo.VrumApp.Domain.Service
{
    public interface ITokenService
    {
        string GenerateToken(User user);

    }
}
