using AutoMapper;
using AutoMapper.QueryableExtensions;
using DfE.CoreLibs.Caching.Helpers;
using DfE.CoreLibs.Caching.Interfaces;
using CaseWorkDesktopTool.Application.Common.Models;
using CaseWorkDesktopTool.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CaseWorkDesktopTool.Application.Schools.Queries.GetPrincipalsBySchools
{
    public record GetPrincipalsBySchoolsQuery(List<string> SchoolNames) : IRequest<Result<List<Principal>>>;

    public class GetPrincipalsBySchoolsQueryHandler(
        ISchoolRepository schoolRepository,
        IMapper mapper,
        ICacheService<IMemoryCacheType> cacheService)
        : IRequestHandler<GetPrincipalsBySchoolsQuery, Result<List<Principal>>>
    {
        public async Task<Result<List<Principal>>> Handle(GetPrincipalsBySchoolsQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"Principal_{CacheKeyHelper.GenerateHashedCacheKey(request.SchoolNames)}";

            var methodName = nameof(GetPrincipalsBySchoolsQueryHandler);

            return await cacheService.GetOrAddAsync(cacheKey, async () =>
            {
                var schoolsQuery = schoolRepository
                    .GetPrincipalsBySchoolsQueryable(request.SchoolNames);

                var membersOfParliament = await schoolsQuery
                    .ProjectTo<Principal>(mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<Principal>>.Success(membersOfParliament);

            }, methodName);
        }
    }

}
