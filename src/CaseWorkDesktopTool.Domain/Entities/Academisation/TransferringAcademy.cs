using CaseWorkDesktopTool.Domain.Common;
using CaseWorkDesktopTool.Domain.ValueObjects;

namespace CaseWorkDesktopTool.Domain.Entities.Academisation
{
    public class TransferringAcademy : BaseAggregateRoot, IEntity<TransferringAcademyId>
    {
        public TransferringAcademyId Id { get; }

        public TransferProjectId? TransferProjectId { get; private set; }

        public string? IncomingTrustUkprn { get; private set; }

        public string? IncomingTrustName { get; private set; }

        public TransferProject? TransferProject { get; private set; }
    }
}
