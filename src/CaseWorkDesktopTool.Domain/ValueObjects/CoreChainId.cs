using CaseWorkDesktopTool.Domain.Common;

namespace CaseWorkDesktopTool.Domain.ValueObjects
{
    public record CoreChainId(double Value) : IStronglyTypedId;
}
