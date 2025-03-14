using CaseWorkDesktopTool.Domain.Common;

namespace CaseWorkDesktopTool.Domain.ValueObjects
{

    public record class SigChangeTypeId(int Value) : IStronglyTypedId;
}
