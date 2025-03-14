using CaseWorkDesktopTool.Domain.Common;
using CaseWorkDesktopTool.Domain.enums;
using CaseWorkDesktopTool.Domain.ValueObjects;

namespace CaseWorkDesktopTool.Domain.Entities.Academisation
{
    public sealed class Project : BaseAggregateRoot, IEntity<ProjectId>
    {
        public ProjectId Id { get; }

        public int? Urn { get; private set; }

        public string? ApplicationReferenceNumber { get; private set; }

        public string? SchoolName { get; private set; }

        public string? LocalAuthority { get; private set; }

        public string? Region { get; private set; }

        public string? AcademyTypeAndRoute { get; private set; }

        public string? NameOfTrust { get; private set; }

        public string? AssignedUserEmailAddress { get; private set; }

        public string? AssignedUserFullName { get; private set; }

        public ProjectStatus? ProjectStatus { get; private set; }

        public string? TrustReferenceNumber { get; private set; }

        public DateTime? CreatedOn { get; private set; }

        public ConversionAdvisoryBoardDecision? ConversionAdvisoryBoardDecision { get; private set; }
    }
}
