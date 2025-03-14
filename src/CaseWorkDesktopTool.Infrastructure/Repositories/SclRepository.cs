using System.Diagnostics.CodeAnalysis;
using CaseWorkDesktopTool.Domain.Common;
using CaseWorkDesktopTool.Domain.Interfaces.Repositories;
using CaseWorkDesktopTool.Infrastructure.Database;

namespace CaseWorkDesktopTool.Infrastructure.Repositories
{
    [ExcludeFromCodeCoverage]
    public class SclRepository<TAggregate>(SclContext dbContext)
        : Repository<TAggregate, SclContext>(dbContext), ISclRepository<TAggregate>
        where TAggregate : class, IAggregateRoot
    {
    }
}