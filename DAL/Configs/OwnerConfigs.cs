using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configs
{
    class OwnerConfigs : EntityTypeConfiguration<Owner>
    {
        public OwnerConfigs()
        {
            HasRequired<LandLot>(o => o.LandLot).WithRequiredPrincipal(ll => ll.Owner);
            
            HasMany<PhysicalIndividual>(o => o.PhysicalIndividuals)
                .WithMany(p => p.Owners).Map(cs =>
                {
                    cs.MapLeftKey("OwnerRefId");
                    cs.MapRightKey("PhysicalIndividualRefId");
                    cs.ToTable("OwnerPhysicalIndividual");
                });

            HasOptional<JuridicalIndividual>(o=>o.JuridicalIndividual).WithMany(j=>j.Owners).HasForeignKey(o=>o.JuridicalIndividualId)
        }
    }
}
