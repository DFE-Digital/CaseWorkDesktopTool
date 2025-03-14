using MediatR;

namespace CaseWorkDesktopTool.Domain.Common
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}
