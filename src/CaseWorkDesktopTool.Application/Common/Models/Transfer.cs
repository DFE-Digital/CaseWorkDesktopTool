using CaseWorkDesktopTool.Domain.enums;

namespace CaseWorkDesktopTool.Application.Common.Models

{
    public class Transfer
    {
        /// <summary>
        /// ProjectId
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ProjectUrn
        /// </summary>
        public int? Urn { get; set; }

        public string? ProjectReference { get; set; }

        public string? OutgoingTrustUkprn { get; set; }

        public string? OutgoingTrustName { get; set; }

        public string? TypeOfTransfer { get; set; }

        public DateTime? TargetDateForTransfer { get; set; }

        public string? AssignedUserEmailAddress { get; set; }

        public string? AssignedUserFullName { get; set; }

        public ProjectStatus? Status { get; set; }

        /// <summary>
        /// TransferringAcademy.IncomingTrustUkprn
        /// </summary>
        public string? IncomingTrustUkprn { get; set; }

        /// <summary>
        /// TransferringAcademy.IncomingTrustName
        /// </summary>
        public string? IncomingTrustName { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
