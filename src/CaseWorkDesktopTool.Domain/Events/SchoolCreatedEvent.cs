using CaseWorkDesktopTool.Domain.Common;
using CaseWorkDesktopTool.Domain.Entities.Schools;

namespace CaseWorkDesktopTool.Domain.Events
{
    public class SchoolCreatedEvent(School school) : IDomainEvent
    {
        public School School { get; } = school;

        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}
