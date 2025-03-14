using AutoFixture;
using CaseWorkDesktopTool.Domain.Entities.Schools;
using CaseWorkDesktopTool.Domain.ValueObjects;

namespace CaseWorkDesktopTool.Tests.Common.Customizations.Entities
{
    public class SchoolCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<School>(composer => composer.FromFactory(() =>
            {
                var constituencyId = fixture.Create<SchoolId>();
                var principalId = fixture.Create<PrincipalId>();
                var nameDetails = new NameDetails(
                    "Doe, John",
                    "John Doe",
                    "Mr. John Doe MP"
                );

                return new School(
                    constituencyId,
                    principalId,
                    fixture.Create<string>(),
                    nameDetails,
                    fixture.Create<DateTime>(),
                    DateOnly.FromDateTime(fixture.Create<DateTime>().Date),
                    fixture.Create<PrincipalDetails>()
                );
            }));
        }
    }
}
