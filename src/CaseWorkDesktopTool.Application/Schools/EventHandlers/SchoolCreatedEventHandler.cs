using CaseWorkDesktopTool.Application.Common.EventHandlers;
using CaseWorkDesktopTool.Domain.Events;
using Microsoft.Extensions.Logging;

namespace CaseWorkDesktopTool.Application.Schools.EventHandlers
{
    public class SchoolCreatedEventHandler(ILogger<SchoolCreatedEventHandler> logger)
        : BaseEventHandler<SchoolCreatedEvent>(logger)
    {
        protected override Task HandleEvent(SchoolCreatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Test logic for SchoolCreatedEvent executed.");
            return Task.CompletedTask;
        }
    }
}
