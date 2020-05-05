using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    public class StateRegistrationInfoConfig : EntityTypeConfiguration<StateRegistrationInfo>
    {
        public StateRegistrationInfoConfig()
        {
            Property(s => s.TechnicalDocumentation).IsRequired();
            Property(s => s.RegistrationAgency).IsRequired();
            Property(s => s.DateTime).IsRequired();

            HasRequired<LandLot>(s => s.LandLot).WithRequiredPrincipal(ll => ll.StateRegistrationInfo);

        }
    }
}
