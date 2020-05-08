using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class MonetaryValuation
    {
        public int Id { get; set; }
        public double Km { get; set; }
        public double Kf { get; set; }
        public decimal Value { get; set; }
        // Foreign key
        public int LandLotId { get; set; }       
        // Navigation properties
        public virtual LandLot LandLot { get; set; }
    }
}
