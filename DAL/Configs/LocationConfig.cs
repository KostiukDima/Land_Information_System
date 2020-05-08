using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    public class LocationConfig : EntityTypeConfiguration<Location>
    {
        public LocationConfig()
        {
            Property(l => l.Region).IsRequired();
            Property(l => l.District).IsRequired();
            Property(l => l.Settlement).IsOptional();
            Property(l => l.Street).IsOptional();
            
            HasRequired<LandLot>(l => l.LandLot).WithRequiredPrincipal(ll => ll.Location);
        }
    }
}
