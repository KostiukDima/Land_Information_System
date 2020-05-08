using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    public class PhysicalIndividualConfig : EntityTypeConfiguration<PhysicalIndividual>
    {
        public PhysicalIndividualConfig()
        {
            Property(j => j.Name).IsRequired();
            Property(j => j.Surname).IsRequired();
            Property(j => j.MiddleName).IsRequired();
            Property(j => j.DateOfBirth).IsRequired();
                
        }
    }
}
