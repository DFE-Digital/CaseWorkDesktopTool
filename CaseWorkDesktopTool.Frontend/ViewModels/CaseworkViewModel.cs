using CaseWorkDesktopTool.Application.Common.Models;

namespace CaseWorkDesktopTool.Frontend.ViewModels
{
    public class CaseworkViewModel<TData> : BaseModel where TData : class
    {
        public required TData Data { get; set; }
    }
}
