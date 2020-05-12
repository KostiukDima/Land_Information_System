using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PhysicalIndividual
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Navigation properties
        public virtual ICollection<Owner> Owners { get; set; }

        public PhysicalIndividual()
        {
            Owners = new HashSet<Owner>();
        }
    }
}
