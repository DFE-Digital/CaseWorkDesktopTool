using System.Text.Json;

namespace CaseWorkDesktopTool.Api.ResponseModels
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
