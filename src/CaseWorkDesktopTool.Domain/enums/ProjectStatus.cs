using System.Runtime.Serialization;

namespace CaseWorkDesktopTool.Domain.enums
{
    public enum ProjectStatus
    {
        [EnumMember(Value = "Active")]
        Active,
        [EnumMember(Value = "Deferred")]
        Deferred,
        [EnumMember(Value = "Approved")]
        Approved,
        [EnumMember(Value = " with Conditions")]
        ApprovedWithCondition,
        [EnumMember(Value = "DAO Revoked")]
        DaoRevoked,
        [EnumMember(Value = "Converter Pre-AO (C)")]
        ConverterPreAo,
        [EnumMember(Value = "Withdrawn")]
        Withdrawn
    }
}
