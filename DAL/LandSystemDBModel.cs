namespace DAL
{
    using DAL.Models;
    using DAL.Configs;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class LandSystemDBModel : DbContext
    {

        public LandSystemDBModel()
            : base("name=LandSystemDBModel")
        {
            Database.SetInitializer(new DBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ChangingConfig());
            modelBuilder.Configurations.Add(new ExploitationTypeConfig());
            modelBuilder.Configurations.Add(new JuridicalIndividualConfig());
            modelBuilder.Configurations.Add(new LandCategoryConfig());
            modelBuilder.Configurations.Add(new LandLotConfig());
            modelBuilder.Configurations.Add(new LocationConfig());
            modelBuilder.Configurations.Add(new MonetaryValuationConfig());
            modelBuilder.Configurations.Add(new OrderConfig());
            modelBuilder.Configurations.Add(new OwnerConfig());
            modelBuilder.Configurations.Add(new OwnershipTypeConfig());
            modelBuilder.Configurations.Add(new PhysicalIndividualConfig());
            modelBuilder.Configurations.Add(new PurposeConfig());
            modelBuilder.Configurations.Add(new SoilConfig());
            modelBuilder.Configurations.Add(new StateRegistrationInfoConfig());

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public virtual DbSet<ExploitationType> ExploitationTypes { get; set; }
        public virtual DbSet<JuridicalIndividual>  JuridicalIndividuals{ get; set; }
        public virtual DbSet<LandCategory> LandCategories { get; set; }
        public virtual DbSet<LandLot> LandLots { get; set; }
        public virtual DbSet<Location>  Locations{ get; set; }
        public virtual DbSet<MonetaryValuation>  MonetaryValuations{ get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<OwnershipType> OwnershipTypes { get; set; }
        public virtual DbSet<PhysicalIndividual>  PhysicalIndividuals{ get; set; }
        public virtual DbSet<Purpose> Purposes { get; set; }
        public virtual DbSet<Soil>  Soils{ get; set; }
        public virtual DbSet<StateRegistrationInfo>  StateRegistrationInfos{ get; set; }
        public virtual DbSet<Changing>  Changings { get; set; }

    }
}