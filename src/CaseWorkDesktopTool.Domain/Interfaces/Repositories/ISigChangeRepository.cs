using CaseWorkDesktopTool.Domain.Entities.SigChange;

namespace CaseWorkDesktopTool.Domain.Interfaces.Repositories
{
    public interface ISigChangeRepository
    {
        Task<IEnumerable<SigChangeTracker>> GetTrackersByUsernameAsync(string username, CancellationToken cancellationToken);

        Task<CoreChain?> GetCoreChainByUrnAsync(double urn, CancellationToken cancellationToken);
    }
}
