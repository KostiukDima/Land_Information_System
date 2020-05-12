using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Owner
    {
        public int Id { get; set; }
        // Foreign key
        public int? LandLotId { get; set; }
        public int? JuridicalIndividualId { get; set; }
        // Navigation properties
        public virtual LandLot LandLot { get; set; }
        public virtual JuridicalIndividual JuridicalIndividual { get; set; }
        public virtual ICollection<PhysicalIndividual> PhysicalIndividuals { get; set; }

        public Owner()
        {
            PhysicalIndividuals = new HashSet<PhysicalIndividual>();            
        }
    }
}
