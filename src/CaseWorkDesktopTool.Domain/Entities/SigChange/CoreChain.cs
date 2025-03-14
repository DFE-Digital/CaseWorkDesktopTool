using CaseWorkDesktopTool.Domain.ValueObjects;

namespace CaseWorkDesktopTool.Domain.Entities.SigChange
{
    public class CoreChain
    {
        public CoreChainId Id { get; }

        public string? LocalAuthority { get; private set; }

        public string? Region { get; private set; }

        public string? TrustName { get; private set; }

        public string? AcademyName { get; private set; }

        public DateTime? DateStamp { get; private set; }
    }
}
