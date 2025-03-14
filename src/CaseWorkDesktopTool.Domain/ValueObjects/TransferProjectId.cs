using CaseWorkDesktopTool.Domain.Common;

namespace CaseWorkDesktopTool.Domain.ValueObjects
{
    public record TransferProjectId(int Value) : IStronglyTypedId;
}
