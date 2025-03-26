using CaseWorkDesktopTool.Domain.Entities.SigChange;
using CaseWorkDesktopTool.Domain.Interfaces.Repositories;
using CaseWorkDesktopTool.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CaseWorkDesktopTool.Infrastructure.Repositories
{
    public class SigChangeRepository(SigChangeContext context) : ISigChangeRepository
    {
        public async Task<IEnumerable<Tracker>> GetTrackersAsync(string username, CancellationToken cancellationToken)
        {
            string sql = "WITH LatestChains AS (" +
                "SELECT * " +
                "FROM (" +
                "SELECT ch.*,ROW_NUMBER() OVER (PARTITION BY ch.URN ORDER BY ch.DateStamp DESC) AS rn " +
                "FROM [00_Core].[Chains] ch" +
                ") t " +
                "WHERE rn = 1 " +
                ") " +
                "SELECT " +
                "st.[sig_change_id] " +
                ", st.[URN] " +
                ", st.[type_of_sig_change_id] " +
                ", sct.[type_of_sig_change] " +
                ", sct.[user_name] " +
                ", st.[application_type] " +
                ", st.[decision_date] " +
                ", st.[delivery_lead] " +
                ", st.[change_creation_date] " +
                ", st.[all_actions_completed] " +
                ", st.[withdrawn] " +
                ", ch.[Local_Authority] " +
                ", ch.[Region] " +
                ", ch.[Trust_Name] " +
                ", ch.[Academy_Name] " +
                ", ch.[DateStamp] " +
                "FROM [01_sigchange].[tracker] st " +
                "INNER JOIN [Data_Insight_Team].[01_sigchange].[sigchangetype] sct on sct.[type_of_sig_change_id] = st.[type_of_sig_change_id] " +
                "LEFT JOIN LatestChains ch ON st.URN = CAST(ch.URN AS INT) " +
                $"WHERE st.[delivery_lead] = '{username}' ";


            return await context.Trackers
                .FromSqlRaw(sql)
                .ToListAsync(cancellationToken);
        }
    }
}
