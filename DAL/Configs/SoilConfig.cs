using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    public class SoilConfig : EntityTypeConfiguration<Soil>
    {
        public SoilConfig()
        {
            Property(p => p.AgroGroupCode).IsRequired();
            Property(p => p.Name).IsRequired();
            HasMany<LandLot>(s => s.LandLots).WithOptional(ll => ll.Soil).HasForeignKey(l => l.SoilId);

        }
    }
}
