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
            AcademyTypeAndRoute = project.AcademyTypeAndRoute,
            NameOfTrust = project.NameOfTrust,
            AssignedUserEmailAddress = project.AssignedUserEmailAddress,
            AssignedUserFullName = project.AssignedUserFullName,
            ProjectStatus = project.ProjectStatus,
            TrustReferenceNumber = project.TrustReferenceNumber,
            CreatedOn = project.CreatedOn
        };

        if (project.ConversionAdvisoryBoardDecision is not null)
        {
            conversion.Decision = project.ConversionAdvisoryBoardDecision.Decision;
            conversion.ConversionTransferDate = project.ConversionAdvisoryBoardDecision.AdvisoryBoardDecisionDate;
        }


        CaseworkViewModel<Conversion> model = new CaseworkViewModel<Conversion>
        {
            Type = CaseworkType.Conversion,
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
            SortDate = project.CreatedOn!.Value,
            Data = transfer
        };

        return model;
    }

    private CaseworkViewModel<SigChange> MapSigChanges(SigChangeTracker sigChange, CoreChain? chain)
    {
        var model = new SigChange
        {
            Urn = sigChange.Urn,
            ApplicationType = sigChange.ApplicationType,
            DecisionDate = sigChange.DecisionDate,
            DeliveryLead = sigChange.DeliveryLead,
            ChangeCreationDate = sigChange.ChangeCreationDate,
            AllActionsCompleted = sigChange.AllActionsCompleted,
            Withdrawn = sigChange.Withdrawn
        };

        if (sigChange.SigChangeType != null)
        {
            model.TypeOfSigChange = sigChange.SigChangeType!.TypeOfSigChange;
            model.Username = sigChange.SigChangeType!.Username;
        }

        if (chain != null)
        {
            model.LocalAuthority = chain.LocalAuthority;
            model.Region = chain.Region;
            model.TrustName = chain.TrustName;
            model.AcademyName = chain.AcademyName;
            model.DateStamp = chain.DateStamp;
        }

        CaseworkViewModel<SigChange> result = new CaseworkViewModel<SigChange>
        {
            Type = CaseworkType.SigChange,
            SortDate = model.ChangeCreationDate!.Value,
            Data = model
        };

        return result;
    }

    public async Task OnGetAsync()
    {
        //var test = await _academisationRepository.GetConversionProjectByIdAsync(22073, CancellationToken.None);

        List<BaseModel> records = new List<BaseModel>();

        var email = User.Identity?.Name!;

        // Sig Changes
        var sigChanges = await _sigChangeRepository.GetTrackersByUsernameAsync("Asim Rasib", CancellationToken.None);

        foreach (var sigChange in sigChanges)
        {
            var chain = await _sigChangeRepository.GetCoreChainByUrnAsync(sigChange.Urn!.Value, CancellationToken.None);

            records.Add(MapSigChanges(sigChange, chain));
        }

        // Conversion
        var conversions = await _academisationRepository.GetConversionProjectsByAssignedUserEmailAddressAsync("Richika.DOGRA@education.gov.uk", CancellationToken.None);

        foreach (Project project in conversions)
        {
            records.Add(MapConversion(project));
        }

        // Transfers
        var transfers = await _academisationRepository.GetTransferProjectsByAssignedUserEmailAddressAsync("Richika.DOGRA@education.gov.uk", CancellationToken.None);

        foreach (TransferProject project in transfers)
        {
            records.Add(MapTransfer(project));
        }

        CaseWorks = records.OrderByDescending(x => x.SortDate).ToList();

        //var record = list[0] as CaseworkViewModel<Conversion>;
    }
}
