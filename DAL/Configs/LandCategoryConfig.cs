using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    class LandCategoryConfig : EntityTypeConfiguration<LandCategory>
    {
        public LandCategoryConfig()
        {
            Property(l => l.Name).IsRequired();

            HasMany<LandLot>(l => l.LandLots).WithRequired(ll => ll.LandCategory).HasForeignKey(l=>l.LandCategoryId);

        }

    }
}
