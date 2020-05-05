using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    public class JuridicalIndividualConfig : EntityTypeConfiguration<JuridicalIndividual>
    {
        public JuridicalIndividualConfig()
        {
            Property(j => j.Name).IsRequired();
            Property(j => j.EDRPOUcode).IsRequired();

            //HasMany<Owner>(j => j.Owners).WithRequired(o => o.JuridicalIndividual).HasForeignKey(o => o.JuridicalIndividualId);
        }
    }
}
