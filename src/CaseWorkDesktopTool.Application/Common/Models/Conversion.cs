using CaseWorkDesktopTool.Domain.enums;

namespace CaseWorkDesktopTool.Application.Common.Models
{
    public class Conversion
    {
        public int Id { get; set; }

        public int? Urn { get; set; }

        /// <summary>
        /// Project reference
        /// </summary>
        public string? ApplicationReferenceNumber { get; set; }

        /// <summary>
        /// Outgoing trust
        /// </summary>
        public string? SchoolName { get; set; }

        public string? LocalAuthority { get; set; }

        public string? Region { get; set; }

        /// <summary>
        /// Route
        /// Possible values: Converter, From a Mat or Sponsored
        /// </summary>
        public string? AcademyTypeAndRoute { get; set; } // Converter - From a Mat - Sponsored

        /// <summary>
        /// UI: Incoming Trust
        /// </summary>
        public string? NameOfTrust { get; set; }

        public string? AssignedUserEmailAddress { get; set; }

        public string? AssignedUserFullName { get; set; }

        public ProjectStatus? ProjectStatus { get; set; }

        public string? TrustReferenceNumber { get; set; }

        /// <summary>
        /// ConversionAdvisoryBoardDecision.Decision
        /// </summary>
        public string? Decision { get; set; }

        /// <summary>
        /// ConversionAdvisoryBoardDecision.AdvisoryBoardDecisionDate
        /// </summary>
        public DateTime? ConversionTransferDate { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
