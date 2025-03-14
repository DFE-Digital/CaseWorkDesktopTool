using CaseWorkDesktopTool.Domain.Common;

namespace CaseWorkDesktopTool.Domain.ValueObjects
{
    public record SigChangeTrackerId(int Value) : IStronglyTypedId;
}
