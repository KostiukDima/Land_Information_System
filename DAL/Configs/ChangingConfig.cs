using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    public class ChangingConfig : EntityTypeConfiguration<Changing>
    {
        public ChangingConfig()
        {
            Property(c => c.Description).IsRequired();
            HasRequired<LandLot>(c => c.LandLot).WithMany(ll => ll.Changings).HasForeignKey(ll => ll.LandLotId);

        }
    }
}
