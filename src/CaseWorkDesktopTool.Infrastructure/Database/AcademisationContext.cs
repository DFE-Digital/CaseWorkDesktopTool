using CaseWorkDesktopTool.Domain.Entities.Academisation;
using CaseWorkDesktopTool.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseWorkDesktopTool.Infrastructure.Database
{
    public class AcademisationContext : DbContext
    {
        const string _academisationSchema = "academisation";

        public AcademisationContext(DbContextOptions<AcademisationContext> options)
        : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; } = null!;

        public DbSet<TransferProject> TransferProjects { get; set; } = null!;

        public DbSet<TransferringAcademy> TransferringAcademies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(ConfigureProject);
            modelBuilder.Entity<TransferProject>(ConfigureTransferProject);
            modelBuilder.Entity<TransferringAcademy>(ConfigureTransferringAcademy);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureProject(EntityTypeBuilder<Project> projectConfiguration)
        {
            projectConfiguration.ToTable("Project", _academisationSchema);

            projectConfiguration.HasKey(s => s.Id);
            projectConfiguration.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(
                v => v!.Value,
                v => new ProjectId(v));

            projectConfiguration.Property(e => e.Urn).HasColumnName("Urn").IsRequired();
            projectConfiguration.Property(e => e.ApplicationReferenceNumber).HasColumnName("ApplicationReferenceNumber");
            projectConfiguration.Property(e => e.SchoolName).HasColumnName("SchoolName");
            projectConfiguration.Property(e => e.LocalAuthority).HasColumnName("LocalAuthority");
            projectConfiguration.Property(e => e.Region).HasColumnName("Region");
            projectConfiguration.Property(e => e.AcademyTypeAndRoute).HasColumnName("AcademyTypeAndRoute");
            projectConfiguration.Property(e => e.NameOfTrust).HasColumnName("NameOfTrust");
            projectConfiguration.Property(e => e.AssignedUserEmailAddress).HasColumnName("AssignedUserEmailAddress");
            projectConfiguration.Property(e => e.AssignedUserFullName).HasColumnName("AssignedUserFullName");
            projectConfiguration.Property(e => e.ProjectStatus).HasColumnName("ProjectStatus");
            projectConfiguration.Property(e => e.TrustReferenceNumber).HasColumnName("TrustReferenceNumber");
            projectConfiguration.Property(e => e.CreatedOn).HasColumnName("CreatedOn");
            projectConfiguration.Property(e => e.GiasGroupUid).HasColumnName("Group UID");
            projectConfiguration.Property(e => e.GiasGroupName).HasColumnName("Group Name");
            projectConfiguration.Property(e => e.Decision).HasColumnName("Decision");
            projectConfiguration.Property(e => e.AdvisoryBoardDecisionDate).HasColumnName("AdvisoryBoardDecisionDate");
        }

        private void ConfigureTransferProject(EntityTypeBuilder<TransferProject> transferProjectConfiguration)
        {
            transferProjectConfiguration.ToTable("TransferProject", _academisationSchema);

            transferProjectConfiguration.HasKey(s => s.Id);
            transferProjectConfiguration.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(
                v => v!.Value,
                v => new TransferProjectId(v));

            transferProjectConfiguration.Property(e => e.Urn).HasColumnName("Urn");
            transferProjectConfiguration.Property(e => e.ProjectReference).HasColumnName("ProjectReference");
            transferProjectConfiguration.Property(e => e.OutgoingTrustUkprn).HasColumnName("OutgoingTrustUkprn");
            transferProjectConfiguration.Property(e => e.OutgoingTrustName).HasColumnName("OutgoingTrustName");
            transferProjectConfiguration.Property(e => e.TypeOfTransfer).HasColumnName("TypeOfTransfer");
            transferProjectConfiguration.Property(e => e.TargetDateForTransfer).HasColumnName("TargetDateForTransfer");
            transferProjectConfiguration.Property(e => e.AssignedUserEmailAddress).HasColumnName("AssignedUserEmailAddress");
            transferProjectConfiguration.Property(e => e.AssignedUserFullName).HasColumnName("AssignedUserFullName");
            transferProjectConfiguration.Property(e => e.CreatedOn).HasColumnName("CreatedOn");

            transferProjectConfiguration
                .HasOne(e => e.TransferringAcademy)
                .WithOne(e => e.TransferProject)
                .HasForeignKey<TransferringAcademy>(e => e.TransferProjectId)
                .IsRequired(false);
        }

        private void ConfigureTransferringAcademy(EntityTypeBuilder<TransferringAcademy> transferringAcademyConfiguration)
        {
            transferringAcademyConfiguration.ToTable("TransferringAcademy", _academisationSchema);

            transferringAcademyConfiguration.HasKey(s => s.Id);
            transferringAcademyConfiguration.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasConversion(
                    v => v!.Value,
                    v => new TransferringAcademyId(v));

            transferringAcademyConfiguration.Property(e => e.TransferProjectId)
                .HasConversion(
                    v => v.Value,
                    v => new TransferProjectId(v));

            transferringAcademyConfiguration.Property(e => e.IncomingTrustUkprn).HasColumnName("IncomingTrustUkprn");
            transferringAcademyConfiguration.Property(e => e.IncomingTrustName).HasColumnName("IncomingTrustName");
        }
    }
}
