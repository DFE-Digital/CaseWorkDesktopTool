using CaseWorkDesktopTool.Application.Common.Models;
using CaseWorkDesktopTool.Domain.Entities.Academisation;
using CaseWorkDesktopTool.Domain.Entities.SigChange;
using CaseWorkDesktopTool.Domain.Interfaces.Repositories;
using CaseWorkDesktopTool.Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CaseWorkDesktopTool.Frontend.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IAcademisationRepository _academisationRepository;
    private readonly ISigChangeRepository _sigChangeRepository;

    public IndexModel(ILogger<IndexModel> logger, IAcademisationRepository academisationRepository, ISigChangeRepository sigChangeRepository)
    {
        _logger = logger;
        _academisationRepository = academisationRepository;
        _sigChangeRepository = sigChangeRepository;
    }

    public List<BaseModel> CaseWorks { get; set; }

    private CaseworkViewModel<Conversion> MapConversion(Project project)
    {
        Conversion conversion = new Conversion
        {
            Id = project.Id.Value,
            Urn = project.Urn,
            ApplicationReferenceNumber = project.ApplicationReferenceNumber,
            SchoolName = project.SchoolName,
            LocalAuthority = project.LocalAuthority,
            Region = project.Region,
            Type = project.AcademyTypeAndRoute == "Sponsored" ? "Sponsored conversion" : "Voluntary conversion",
            NameOfTrust = project.NameOfTrust,
            AssignedUserEmailAddress = project.AssignedUserEmailAddress,
            AssignedUserFullName = project.AssignedUserFullName,
            ProjectStatus = project.ProjectStatus,
            TrustReferenceNumber = project.TrustReferenceNumber,
            CreatedOn = project.CreatedOn,
            GiasGroupUid = project.GiasGroupUid,
            GiasGroupName = project.GiasGroupName,
            Decision = project.Decision,
            ConversionTransferDate = project.AdvisoryBoardDecisionDate,
        };

        CaseworkViewModel<Conversion> model = new CaseworkViewModel<Conversion>
        {
            Type = CaseworkType.Conversion,
            SystemType = "Prepare",
            Label = "Conversion",
            Title = project.SchoolName,
            TitleId = project.Id.Value,
            SortDate = project.CreatedOn!.Value,
            Data = conversion
        };

        return model;
    }

    private CaseworkViewModel<Transfer> MapTransfer(TransferProject project)
    {
        Transfer transfer = new Transfer
        {
            Id = project.Id.Value,
            Urn = project.Urn,
            ProjectReference = project.ProjectReference,
            OutgoingTrustUkprn = project.OutgoingTrustUkprn,
            OutgoingTrustName = project.OutgoingTrustName,
            TypeOfTransfer = project.TypeOfTransfer,
            TargetDateForTransfer = project.TargetDateForTransfer,
            AssignedUserEmailAddress = project.AssignedUserEmailAddress,
            AssignedUserFullName = project.AssignedUserFullName,
            Status = project.Status,
            CreatedOn = project.CreatedOn
        };

        if (project.TransferringAcademy is not null)
        {
            transfer.IncomingTrustUkprn = project.TransferringAcademy.IncomingTrustUkprn;
            transfer.IncomingTrustName = project.TransferringAcademy.IncomingTrustName;
        }

        CaseworkViewModel<Transfer> model = new CaseworkViewModel<Transfer>
        {
            Type = CaseworkType.Transfer,
            SystemType = "Prepare",
            Label = "Transfer",
            Title = project.TransferringAcademy?.IncomingTrustName,
            TitleId = project.Urn,
            SortDate = project.CreatedOn!.Value,
            Data = transfer
        };

        return model;
    }

    private CaseworkViewModel<SigChange> MapTracker(Tracker tracker)
    {
        var model = new SigChange
        {
            Urn = tracker.Urn,
            TypeOfSigChange = tracker.TypeOfSigChange,
            Username = tracker.Username,
            ApplicationType = tracker.ApplicationType,
            DecisionDate = tracker.DecisionDate,
            DeliveryLead = tracker.DeliveryLead,
            ChangeCreationDate = tracker.ChangeCreationDate,
            AllActionsCompleted = tracker.AllActionsCompleted,
            Withdrawn = tracker.Withdrawn,
            LocalAuthority = tracker.LocalAuthority,
            Region = tracker.Region,
            TrustName = tracker.TrustName,
            AcademyName = tracker.AcademyName,
            DateStamp = tracker.DateStamp
        };

        CaseworkViewModel<SigChange> result = new CaseworkViewModel<SigChange>
        {
            Type = CaseworkType.SigChange,
            SystemType = "Significant Change",
            Label = tracker.TypeOfSigChange,
            Title = tracker.AcademyName,
            SortDate = model.ChangeCreationDate!.Value,
            Data = model
        };

        return result;
    }

    public async Task OnGetAsync()
    {
        List<BaseModel> records = new List<BaseModel>();

        var identity = User.Identity;
        var username = "Ben Memmott"; // Asim Rasib, Richika.DOGRA@education.gov.uk, ben.memmott@education.gov.uk

        var trackers = await _sigChangeRepository.GetTrackersAsync(username, CancellationToken.None);
        foreach (Tracker tracker in trackers)
        {
            records.Add(MapTracker(tracker));
        }

        string email = "Ben.MEMMOTT@education.gov.uk";

        // Conversion
        var conversions = await _academisationRepository.GetConversionProjectsByAssignedUserEmailAddressAsync(email, CancellationToken.None);

        foreach (Project project in conversions)
        {
            records.Add(MapConversion(project));
        }

        // Transfers
        var transfers = await _academisationRepository.GetTransferProjectsByAssignedUserEmailAddressAsync(email, CancellationToken.None);

        foreach (TransferProject project in transfers)
        {
            records.Add(MapTransfer(project));
        }

        CaseWorks = records.OrderByDescending(x => x.SortDate).ToList();
    }
}
