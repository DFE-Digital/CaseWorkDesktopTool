using CaseWorkDesktopTool.Domain.Entities.SigChange;
using CaseWorkDesktopTool.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseWorkDesktopTool.Infrastructure.Database
{
    public class SigChangeContext : DbContext
    {
        const string _sigChange01Schema = "01_sigchange";

        public SigChangeContext(DbContextOptions<SigChangeContext> options)
        : base(options)
        {
        }

        public DbSet<Tracker> Trackers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tracker>(ConfigureTracker);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureTracker(EntityTypeBuilder<Tracker> trackerConfiguration)
        {
            trackerConfiguration.ToTable("tracker", _sigChange01Schema);

            trackerConfiguration.HasKey(s => s.Id);
            trackerConfiguration.Property(e => e.Id).HasColumnName("sig_change_id")
                .HasConversion(
                    v => v!.Value,
                    v => new TrackerId(v));

            trackerConfiguration.Property(e => e.Urn).HasColumnName("URN");
            trackerConfiguration.Property(e => e.TypeOfSigChange).HasColumnName("type_of_sig_change");
            trackerConfiguration.Property(e => e.Username).HasColumnName("user_name");
            trackerConfiguration.Property(e => e.ApplicationType).HasColumnName("application_type");
            trackerConfiguration.Property(e => e.DecisionDate).HasColumnName("decision_date");
            trackerConfiguration.Property(e => e.DeliveryLead).HasColumnName("delivery_lead");
            trackerConfiguration.Property(e => e.ChangeCreationDate).HasColumnName("change_creation_date");
            trackerConfiguration.Property(e => e.AllActionsCompleted).HasColumnName("all_actions_completed");
            trackerConfiguration.Property(e => e.Withdrawn).HasColumnName("withdrawn");
            trackerConfiguration.Property(e => e.LocalAuthority).HasColumnName("Local_Authority");
            trackerConfiguration.Property(e => e.Region).HasColumnName("Region");
            trackerConfiguration.Property(e => e.TrustName).HasColumnName("Trust_Name");
            trackerConfiguration.Property(e => e.AcademyName).HasColumnName("Academy_Name");
            trackerConfiguration.Property(e => e.DateStamp).HasColumnName("DateStamp");
        }
    }
}
