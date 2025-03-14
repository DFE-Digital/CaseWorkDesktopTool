using CaseWorkDesktopTool.Domain.Common;

namespace CaseWorkDesktopTool.Domain.ValueObjects
{
    public record PrincipalId(int Value) : IStronglyTypedId;
}
