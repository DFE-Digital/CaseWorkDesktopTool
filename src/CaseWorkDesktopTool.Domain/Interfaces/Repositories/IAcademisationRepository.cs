using CaseWorkDesktopTool.Domain.Entities.Academisation;

namespace CaseWorkDesktopTool.Domain.Interfaces.Repositories
{
    public interface IAcademisationRepository
    {
        Task<IEnumerable<Project>> GetConversionProjectsByAssignedUserEmailAddressAsync(string assignedUserEmailAddress, CancellationToken cancellationToken);

        Task<IEnumerable<TransferProject>> GetTransferProjectsByAssignedUserEmailAddressAsync(string assignedUserEmailAddress, CancellationToken cancellationToken);

        Task<Project?> GetConversionProjectByIdAsync(int projectId, CancellationToken cancellationToken);
    }
}
