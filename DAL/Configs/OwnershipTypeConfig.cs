using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    public class OwnershipTypeConfig : EntityTypeConfiguration<OwnershipType>
    {
        public OwnershipTypeConfig()
        {
            Property(o => o.Name).IsRequired();

            HasMany<LandLot>(o => o.LandLots).WithRequired(ll => ll.OwnershipType).HasForeignKey(l => l.OwnershipTypeId);

        }
    }
}
