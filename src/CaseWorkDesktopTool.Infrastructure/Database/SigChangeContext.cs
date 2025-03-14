using CaseWorkDesktopTool.Domain.Entities.SigChange;
using CaseWorkDesktopTool.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseWorkDesktopTool.Infrastructure.Database
{
    public class SigChangeContext : DbContext
    {
        const string _sigChange01Schema = "01_sigchange";
        const string _coreChainsSchema = "00_Core";

        public SigChangeContext(DbContextOptions<SigChangeContext> options)
        : base(options)
        {
        }

        public DbSet<SigChangeTracker> SigChangeTrackers { get; set; } = null!;

        public DbSet<SigChangeType> SigChangeTypes { get; set; } = null!;

        public DbSet<CoreChain> CoreChains { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SigChangeTracker>(ConfigureSigChangeTracker);
            modelBuilder.Entity<SigChangeType>(ConfigureSigChangeTypes);
            modelBuilder.Entity<CoreChain>(ConfigureCoreChains);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureSigChangeTracker(EntityTypeBuilder<SigChangeTracker> sigChangeTrackerConfiguration)
        {
            sigChangeTrackerConfiguration.ToTable("tracker", _sigChange01Schema);

            sigChangeTrackerConfiguration.HasKey(s => s.Id);
            sigChangeTrackerConfiguration.Property(e => e.Id).HasColumnName("sig_change_id")
                .ValueGeneratedOnAdd()
                .HasConversion(
                    v => v!.Value,
                    v => new SigChangeTrackerId(v));

            sigChangeTrackerConfiguration.Property(e => e.TypeOfSigChangeId).HasColumnName("type_of_sig_change_id");
            sigChangeTrackerConfiguration.Property(e => e.ApplicationType).HasColumnName("application_type");
            sigChangeTrackerConfiguration.Property(e => e.DecisionDate).HasColumnName("decision_date");
            sigChangeTrackerConfiguration.Property(e => e.DeliveryLead).HasColumnName("delivery_lead");
            sigChangeTrackerConfiguration.Property(e => e.ChangeCreationDate).HasColumnName("change_creation_date");
            sigChangeTrackerConfiguration.Property(e => e.AllActionsCompleted).HasColumnName("all_actions_completed");
            sigChangeTrackerConfiguration.Property(e => e.Withdrawn).HasColumnName("withdrawn");

            sigChangeTrackerConfiguration
                .HasOne(e => e.SigChangeType)
                .WithOne(e => e.Tracker)
                .HasForeignKey<SigChangeTracker>(e => e.TypeOfSigChangeId)
                .IsRequired(false);
        }

        private void ConfigureSigChangeTypes(EntityTypeBuilder<SigChangeType> sigChangeTypeConfiguration)
        {
            sigChangeTypeConfiguration.ToTable("sigchangetype", _sigChange01Schema);

            sigChangeTypeConfiguration.HasKey(s => s.Id);
            sigChangeTypeConfiguration.Property(e => e.Id).HasColumnName("type_of_sig_change_id")
                .ValueGeneratedOnAdd()
                .HasConversion(
                    v => v!.Value,
                    v => new SigChangeTypeId(v));

            sigChangeTypeConfiguration.Property(e => e.TypeOfSigChange).HasColumnName("type_of_sig_change").IsRequired();
            sigChangeTypeConfiguration.Property(e => e.Username).HasColumnName("user_name");
        }

        private void ConfigureCoreChains(EntityTypeBuilder<CoreChain> coreChainConfiguration)
        {
            coreChainConfiguration.ToTable("Chains", _coreChainsSchema);

            coreChainConfiguration.HasKey(s => s.Id);
            coreChainConfiguration.Property(e => e.Id).HasColumnName("URN")
                .ValueGeneratedOnAdd()
                .HasConversion(
                    v => v!.Value,
                    v => new CoreChainId(v));


            coreChainConfiguration.Property(e => e.LocalAuthority).HasColumnName("Local_Authority");
            coreChainConfiguration.Property(e => e.Region).HasColumnName("Region");
            coreChainConfiguration.Property(e => e.TrustName).HasColumnName("Trust_Name");
            coreChainConfiguration.Property(e => e.AcademyName).HasColumnName("Academy_Name");
            coreChainConfiguration.Property(e => e.DateStamp).HasColumnName("DateStamp");
        }
    }
}
