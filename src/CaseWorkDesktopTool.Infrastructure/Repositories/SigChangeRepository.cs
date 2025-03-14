using CaseWorkDesktopTool.Domain.Entities.SigChange;
using CaseWorkDesktopTool.Domain.Interfaces.Repositories;
using CaseWorkDesktopTool.Domain.ValueObjects;
using CaseWorkDesktopTool.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CaseWorkDesktopTool.Infrastructure.Repositories
{
    public class SigChangeRepository(SigChangeContext context) : ISigChangeRepository
    {
        public async Task<IEnumerable<SigChangeTracker>> GetTrackersByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return await context.SigChangeTrackers
                .AsNoTracking()
                .Include(x => x.SigChangeType)
                .Where(x => x.DeliveryLead == username && ((x.AllActionsCompleted == null || x.AllActionsCompleted == false) && (x.Withdrawn == null || x.Withdrawn == false)))
                .ToListAsync(cancellationToken);
        }

        public async Task<CoreChain?> GetCoreChainByUrnAsync(double urn, CancellationToken cancellationToken)
        {
            return await context.CoreChains
                .AsNoTracking()
                .OrderByDescending(x => x.DateStamp)
                .FirstOrDefaultAsync(x => x.Id == new CoreChainId(urn), cancellationToken);
        }
    }
}
