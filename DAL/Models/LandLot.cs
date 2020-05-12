using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class LandLot
    {
        // Primary key
        public int Id { get; set; }
        public string CadastralNumber { get; set; }
        public double Area { get; set; }
        // Foreign key
        public int LocationId { get; set; }
        public int PurposeId { get; set; }
        public int LandCategoryId { get; set; }
        public int ExploitationTypeId { get; set; }
        public int OwnershipTypeId { get; set; }
        public int MonetaryValuationId { get; set; }
        public int StateRegistrationInfoId { get; set; }
        public int? SoilId { get; set; }
        public int OwnerId { get; set; }
        // Navigation properties
        public virtual Location Location { get; set; }
        public virtual Purpose Purpose { get; set; }
        public virtual LandCategory LandCategory { get; set; }
        public virtual ExploitationType ExploitationType{ get; set; }
        public virtual OwnershipType OwnershipType { get; set; }
        public virtual MonetaryValuation MonetaryValuation{ get; set; }
        public virtual StateRegistrationInfo StateRegistrationInfo { get; set; }
        public virtual Soil Soil { get; set; }
        public virtual Owner Owner  { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Changing>  Changings { get; set; }

        //public LandLot()
        //{
        //    Order = new HashSet<Order>();
        //    Changings = new HashSet<Changing>();
        //}
    }
}
