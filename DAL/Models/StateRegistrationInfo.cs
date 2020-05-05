using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class StateRegistrationInfo
    {
        public int Id { get; set; }
        public string TechnicalDocumentation { get; set; }
        public string RegistrationAgency { get; set; }
        public DateTime DateTime { get; set; }

        // Foreign key
        public int LandLotId { get; set; }
        // Navigation properties
        public virtual LandLot LandLot { get; set; }

    }
}
