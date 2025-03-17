using CaseWorkDesktopTool.Domain.Common;
using CaseWorkDesktopTool.Domain.ValueObjects;

namespace CaseWorkDesktopTool.Domain.Entities.SigChange
{
    public class SigChangeType : BaseAggregateRoot, IEntity<SigChangeTypeId>
    {
        public SigChangeTypeId Id { get; }

        public string? TypeOfSigChange { get; private set; }

        public string? Username { get; private set; }

        public SigChangeTracker? Tracker { get; private set; }
    }
}
