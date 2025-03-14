using CaseWorkDesktopTool.Domain.Common;

namespace CaseWorkDesktopTool.Domain.ValueObjects
{
    public record TransferringAcademyId(int Value) : IStronglyTypedId;
}
