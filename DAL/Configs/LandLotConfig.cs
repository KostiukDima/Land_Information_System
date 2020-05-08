using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    public class LandLotConfig : EntityTypeConfiguration<LandLot>
    {
        public LandLotConfig()
        {
            Property(l => l.Area).IsRequired();
            Property(l => l.СadastralNumber).IsRequired();
        }
    }
}
