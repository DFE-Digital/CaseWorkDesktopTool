using CaseWorkDesktopTool.Domain.Common;
using CaseWorkDesktopTool.Domain.enums;
using CaseWorkDesktopTool.Domain.ValueObjects;

namespace CaseWorkDesktopTool.Domain.Entities.Academisation
{
    public class TransferProject : BaseAggregateRoot, IEntity<TransferProjectId>
    {
        public TransferProjectId Id { get; }

        public int? Urn { get; private set; }

        public string? ProjectReference { get; private set; }

        public string? OutgoingTrustUkprn { get; private set; }

        public string? OutgoingTrustName { get; private set; }

        public string? TypeOfTransfer { get; private set; }

        public DateTime? TargetDateForTransfer { get; private set; }

        public string? AssignedUserEmailAddress { get; private set; }

        public string? AssignedUserFullName { get; private set; }

        public ProjectStatus? Status { get; private set; }

        public DateTime? CreatedOn { get; private set; }

        public TransferringAcademy? TransferringAcademy { get; private set; }
    }
}
