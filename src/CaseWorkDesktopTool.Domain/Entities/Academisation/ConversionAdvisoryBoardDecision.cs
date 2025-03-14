using CaseWorkDesktopTool.Domain.Common;
using CaseWorkDesktopTool.Domain.Entities.Schools;
using CaseWorkDesktopTool.Domain.ValueObjects;

namespace CaseWorkDesktopTool.Domain.Entities.Academisation
{
    public class ConversionAdvisoryBoardDecision : BaseAggregateRoot, IEntity<ConversionAdvisoryBoardDecisionId>
    {
        public ConversionAdvisoryBoardDecisionId Id { get; }

        public ProjectId? ConversionProjectId { get; private set; }

        public string? Decision { get; private set; }

        public DateTime? AdvisoryBoardDecisionDate { get; private set; }

        public Project? Project { get; private set; }
    }
}
