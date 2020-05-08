using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    public class MonetaryValuationConfig : EntityTypeConfiguration<MonetaryValuation>
    {
        public MonetaryValuationConfig()
        {
            Property(m => m.Kf).IsRequired();
            Property(m => m.Km).IsRequired();
            Property(m => m.Value).IsRequired();

            HasRequired<LandLot>(m => m.LandLot).WithRequiredPrincipal(ll => ll.MonetaryValuation);
        }
    }
}
