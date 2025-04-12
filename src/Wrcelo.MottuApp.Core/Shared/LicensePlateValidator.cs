using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wrcelo.VrumApp.Core.Shared
{
    public static class LicensePlateValidator
    {
        private static readonly Regex _plateRegex = new Regex(@"^[A-Z]{3}-?[0-9][A-Z0-9][0-9]{2}$", RegexOptions.IgnoreCase);

        public static bool IsValid(string licensePlate)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                return false;

            return _plateRegex.IsMatch(licensePlate);
        }
    }
}
