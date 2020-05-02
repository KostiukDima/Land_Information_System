using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    class Location
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Settlement { get; set; }
        public string Street { get; set; }

        // Foreign key
        public int LandLotId { get; set; }

        // Navigation properties
        public virtual LandLot LandLot { get; set; }
    }
}
