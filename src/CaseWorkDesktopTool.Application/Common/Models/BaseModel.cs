namespace CaseWorkDesktopTool.Application.Common.Models
{
    public abstract class BaseModel
    {
        public CaseworkType Type { get; set; }

        public DateTime SortDate { get; set; }

        public override string ToString()
        {
            return $"type: {Type} - Date: {SortDate}";
        }
    }
}
