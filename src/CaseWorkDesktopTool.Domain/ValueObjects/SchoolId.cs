using CaseWorkDesktopTool.Domain.Common;

namespace CaseWorkDesktopTool.Domain.ValueObjects
{
    public record SchoolId(int Value) : IStronglyTypedId;

}
