using CaseWorkDesktopTool.Domain.Common;

namespace CaseWorkDesktopTool.Domain.ValueObjects
{
    public record class TrackerId(int Value) : IStronglyTypedId;
}
