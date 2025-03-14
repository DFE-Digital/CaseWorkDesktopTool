using CaseWorkDesktopTool.Application.Schools.Models;
using CaseWorkDesktopTool.Domain.Entities.Schools;
using CaseWorkDesktopTool.Domain.Interfaces.Repositories;
using CaseWorkDesktopTool.Domain.ValueObjects;
using MediatR;

namespace CaseWorkDesktopTool.Application.Schools.Commands.CreateSchool
{
    public record CreateSchoolCommand(
        string SchoolName,
        DateTime LastRefresh,
        DateOnly? EndDate,
        NameDetailsModel NameDetails,
        PrincipalDetailsModel PrincipalDetails
    ) : IRequest<SchoolId>;

    public class CreateSchoolCommandHandler(ISclRepository<School> schoolRepository)
        : IRequestHandler<CreateSchoolCommand, SchoolId>
    {
        public async Task<SchoolId> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = School.Create(
                request.SchoolName,
                new NameDetails(request.NameDetails.FirstName, request.NameDetails.FirstName, request.NameDetails.FirstName),
                request.LastRefresh,
                request.EndDate,
                request.PrincipalDetails.Email,
                request.PrincipalDetails.Phone,
                request.PrincipalDetails.TypeId
            );

            await schoolRepository.AddAsync(school, cancellationToken);

            return school.Id!;
        }
    }
}
