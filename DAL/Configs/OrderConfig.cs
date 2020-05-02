using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    class OrderConfig : EntityTypeConfiguration<Order>
    {
        public OrderConfig()
        {
            Property(o => o.Name).IsRequired();

            HasRequired<LandLot>(o => o.LandLot).WithMany(ll => ll.Order).HasForeignKey(o=>o.LandLotId);

        }
    }
}
