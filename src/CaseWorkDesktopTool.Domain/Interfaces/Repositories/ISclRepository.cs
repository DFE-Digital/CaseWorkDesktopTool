using CaseWorkDesktopTool.Domain.Common;

namespace CaseWorkDesktopTool.Domain.Interfaces.Repositories
{
    public interface ISclRepository<TAggregate> : IRepository<TAggregate>
        where TAggregate : class, IAggregateRoot
    {
    }
}
