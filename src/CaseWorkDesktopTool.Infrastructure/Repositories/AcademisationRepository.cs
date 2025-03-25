using CaseWorkDesktopTool.Domain.Entities.Academisation;
using CaseWorkDesktopTool.Domain.Interfaces.Repositories;
using CaseWorkDesktopTool.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CaseWorkDesktopTool.Infrastructure.Repositories
{
    public class AcademisationRepository(AcademisationContext context) : IAcademisationRepository
    {
        readonly List<string> statuses = ["Active", "Deferred", "Approved", "Approved with Conditions", "DAO Revoked", "Converter Pre-AO (C)", "Withdrawn"];

        public async Task<IEnumerable<Project>> GetConversionProjectsByAssignedUserEmailAddressAsync(string assignedUserEmailAddress, CancellationToken cancellationToken)
        {
            string sql = "select pr.[Id], pr.[Urn], pr.[ApplicationReferenceNumber], pr.[SchoolName], pr.[LocalAuthority] " +
                ", pr.[Region], pr.AcademyTypeAndRoute, pr.[NameOfTrust] " +
                ", [AssignedUserEmailAddress], [AssignedUserFullName] " +
                ", pr.[ProjectStatus], pr.[TrustReferenceNumber], pr.[CreatedOn] " +
                ", gr.[Group UID], gr.[Group Name] " +
                ", bd.[Decision], bd.[AdvisoryBoardDecisionDate] " +
                ", ca.ApplicationStatus " +
                "from [academisation].[Project] as pr " +
                "left join [gias].[Group] gr on gr.[Group ID] = pr.[TrustReferenceNumber] " +
                "left join [academisation].[ConversionAdvisoryBoardDecision] bd on bd.ConversionProjectId = pr.[Id] " +
                "left join [academisation].ConversionApplication ca on ca.ApplicationReference = pr.[ApplicationReferenceNumber] " +
                $"where pr.[AssignedUserEmailAddress] = '{assignedUserEmailAddress}' " +
                "and pr.[ProjectStatus] in ('Active','Deferred','Approved','Approved with Conditions','DAO Revoked','Converter Pre-AO (C)','DAO Revoked')";

            return await context.Projects
                .FromSqlRaw(sql)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TransferProject>> GetTransferProjectsByAssignedUserEmailAddressAsync(string assignedUserEmailAddress, CancellationToken cancellationToken)
        {
            return await context.TransferProjects
                .AsNoTracking()
                .Include(c => c.TransferringAcademy)
                .Where(x => x.AssignedUserEmailAddress == assignedUserEmailAddress && (statuses.Any(s => s == x.Status) || x.Status == null))
                .ToListAsync(cancellationToken);
        }
    }
}
