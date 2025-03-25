using CaseWorkDesktopTool.Domain.Common;
using CaseWorkDesktopTool.Domain.ValueObjects;

namespace CaseWorkDesktopTool.Domain.Entities.SigChange
{
    public class Tracker : BaseAggregateRoot, IEntity<TrackerId>
    {
        public TrackerId Id { get; }

        public int? Urn { get; private set; }

        public string? TypeOfSigChange { get; private set; }

        public string? Username { get; private set; }

        public string? ApplicationType { get; private set; }

        public DateTime? DecisionDate { get; private set; }

        public string? DeliveryLead { get; private set; }

        public DateTime? ChangeCreationDate { get; private set; }

        public bool? AllActionsCompleted { get; private set; }

        public bool? Withdrawn { get; private set; }

        public string? LocalAuthority { get; private set; }

        public string? Region { get; private set; }

        public string? TrustName { get; private set; }

        public string? AcademyName { get; private set; }

        public DateTime? DateStamp { get; private set; }
    }
}
