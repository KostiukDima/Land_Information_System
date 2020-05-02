using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign key
        public int LandLotId { get; set; }

        // Navigation properties
        public virtual LandLot LandLot { get; set; }
    }
}
