using DfE.CoreLibs.AsyncProcessing.Interfaces;
using CaseWorkDesktopTool.Application.Services.BackgroundServices.Events;
using CaseWorkDesktopTool.Application.Services.BackgroundServices.Tasks;
using MediatR;

namespace CaseWorkDesktopTool.Application.Schools.Commands.CreateReport
{
    /// <summary>
    /// An example of enqueuing a background task
    /// </summary>
    public record CreateReportCommand() : IRequest<bool>;

    public class CreateReportCommandHandler( IBackgroundServiceFactory backgroundServiceFactory)
        : IRequestHandler<CreateReportCommand, bool>
    {
        public Task<bool> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var taskName = "Create_Report_Task1";

            backgroundServiceFactory.EnqueueTask(
                async () => await (new CreateReportExampleTask()).RunAsync(taskName),
                result => new CreateReportExampleTaskCompletedEvent(taskName, result)
                );

            return Task.FromResult(true);
        }
    }
}
