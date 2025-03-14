using CaseWorkDesktopTool.Domain.Entities.Academisation;
using CaseWorkDesktopTool.Domain.enums;
using CaseWorkDesktopTool.Domain.Interfaces.Repositories;
using CaseWorkDesktopTool.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CaseWorkDesktopTool.Infrastructure.Repositories
{
    public class AcademisationRepository(AcademisationContext context) : IAcademisationRepository
    {
        readonly List<ProjectStatus> statuses = [ProjectStatus.Active, ProjectStatus.Deferred, ProjectStatus.Approved, ProjectStatus.ApprovedWithCondition, ProjectStatus.DaoRevoked, ProjectStatus.ConverterPreAo, ProjectStatus.DaoRevoked];

        public async Task<Project?> GetConversionProjectByIdAsync(int projectId, CancellationToken cancellationToken)
        {
            return await context.Projects
                .AsNoTracking()
                .Include(c => c.ConversionAdvisoryBoardDecision)
                .FirstOrDefaultAsync(x => x.Id == new Domain.ValueObjects.ProjectId(projectId), cancellationToken);
        }

        public async Task<IEnumerable<Project>> GetConversionProjectsByAssignedUserEmailAddressAsync(string assignedUserEmailAddress, CancellationToken cancellationToken)
        {
            return await context.Projects
                .AsNoTracking()
                .Include(c => c.ConversionAdvisoryBoardDecision)
                .Where(x => x.AssignedUserEmailAddress == assignedUserEmailAddress && statuses.Any(s => s == x.ProjectStatus))
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TransferProject>> GetTransferProjectsByAssignedUserEmailAddressAsync(string assignedUserEmailAddress, CancellationToken cancellationToken)
        {
            return await context.TransferProjects
                .AsNoTracking()
                .Include(c => c.TransferringAcademy)
                .Where(x => x.AssignedUserEmailAddress == assignedUserEmailAddress) //  && statuses.Any(s => s == x.Status)
                .ToListAsync(cancellationToken);
        }
    }
}
