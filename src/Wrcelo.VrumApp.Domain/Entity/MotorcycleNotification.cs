using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrcelo.VrumApp.Domain.Entity
{
    public class MotorcycleNotification
    {
        public Guid Guid { get; set; }
        public Guid MotorcycleGuid { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public DateTime Date{ get; set; }
    }
}
