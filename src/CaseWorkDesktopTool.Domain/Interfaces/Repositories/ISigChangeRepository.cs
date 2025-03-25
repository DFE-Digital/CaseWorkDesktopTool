using CaseWorkDesktopTool.Domain.Entities.SigChange;

namespace CaseWorkDesktopTool.Domain.Interfaces.Repositories
{
    public interface ISigChangeRepository
    {
        Task<IEnumerable<Tracker>> GetTrackersAsync(string username, CancellationToken cancellationToken);
    }
}
