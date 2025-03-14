using CaseWorkDesktopTool.Domain.Common;

namespace CaseWorkDesktopTool.Domain.ValueObjects
{
    public record ProjectId(int Value) : IStronglyTypedId;
}
