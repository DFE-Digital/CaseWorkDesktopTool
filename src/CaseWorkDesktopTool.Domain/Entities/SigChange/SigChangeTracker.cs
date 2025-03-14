using CaseWorkDesktopTool.Domain.Common;
using CaseWorkDesktopTool.Domain.ValueObjects;

namespace CaseWorkDesktopTool.Domain.Entities.SigChange
{
    public class SigChangeTracker : BaseAggregateRoot, IEntity<SigChangeTrackerId>
    {
        public SigChangeTrackerId Id { get; }

        public int? Urn { get; private set; }

        public SigChangeTypeId? TypeOfSigChangeId { get; }

        public string? ApplicationType { get; private set; }

        public DateTime? DecisionDate { get; private set; }

        public string? DeliveryLead { get; private set; }

        public DateTime? ChangeCreationDate { get; private set; }

        public bool? AllActionsCompleted { get; private set; }

        public bool? Withdrawn { get; private set; }

        public SigChangeType? SigChangeType { get; private set; }
    }
}
