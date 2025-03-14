namespace CaseWorkDesktopTool.Domain.Common
{
    public interface IEntity<out TId> where TId : IStronglyTypedId
    {
        TId? Id { get; }
    }
}
