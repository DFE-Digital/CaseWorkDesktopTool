namespace CaseWorkDesktopTool.Application.Common.Models
{
    public class Conversion
    {
        public int Id { get; set; }

        public int? Urn { get; set; }

        public string? ApplicationReferenceNumber { get; set; }

        public string? SchoolName { get; set; }

        public string? LocalAuthority { get; set; }

        public string? Region { get; set; }

        public string? Type { get; set; }

        public string? NameOfTrust { get; set; }

        public string? AssignedUserEmailAddress { get; set; }

        public string? AssignedUserFullName { get; set; }

        public string? ProjectStatus { get; set; }

        public string? TrustReferenceNumber { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? GiasGroupUid { get; set; }

        public string? GiasGroupName { get; set; }

        public string? Decision { get; set; }

        public DateTime? ConversionTransferDate { get; set; }
    }
}
