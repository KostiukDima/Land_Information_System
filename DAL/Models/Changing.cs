using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Changing
    {
        public int Id { get; set; }
        public string Description { get; set; }

        // Foreign key
        public int LandLotId { get; set; }
        // Navigation properties
        public virtual LandLot LandLot { get; set; }
    }
}
