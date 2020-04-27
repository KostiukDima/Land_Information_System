using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    class Сhanging
    {
        public int Id { get; set; }
        public string Description { get; set; }
        // Navigation properties
        public virtual LandLot LandLots { get; set; }
    }
}
