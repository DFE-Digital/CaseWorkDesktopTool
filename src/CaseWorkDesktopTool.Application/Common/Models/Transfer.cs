namespace CaseWorkDesktopTool.Application.Common.Models
{
    public class Transfer
    {
        public int Id { get; set; }

        public int? Urn { get; set; }

        public string? ProjectReference { get; set; }

        public string? OutgoingTrustUkprn { get; set; }

        public string? OutgoingTrustName { get; set; }

        public string? TypeOfTransfer { get; set; }

        public DateTime? TargetDateForTransfer { get; set; }

        public string? AssignedUserEmailAddress { get; set; }

        public string? AssignedUserFullName { get; set; }

        public string? Status { get; set; }

        public string? IncomingTrustUkprn { get; set; }

        public string? IncomingTrustName { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
