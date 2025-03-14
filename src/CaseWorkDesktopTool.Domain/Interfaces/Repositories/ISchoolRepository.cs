using CaseWorkDesktopTool.Domain.Entities.Schools;

namespace CaseWorkDesktopTool.Domain.Interfaces.Repositories
{
    public interface ISchoolRepository
    {
        Task<School?> GetPrincipalBySchoolAsync(string schoolName, CancellationToken cancellationToken);
        IQueryable<School> GetPrincipalsBySchoolsQueryable(List<string> schoolNames);

    }
}
