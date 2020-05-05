using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    public class PurposeConfig : EntityTypeConfiguration<Purpose>
    {
        public PurposeConfig()
        {
            Property(p => p.Code).IsRequired();
            Property(p => p.Name).IsRequired();

            HasMany<LandLot>(p => p.LandLots).WithRequired(ll => ll.Purpose).HasForeignKey(l => l.PurposeId);

        }
    }
}
