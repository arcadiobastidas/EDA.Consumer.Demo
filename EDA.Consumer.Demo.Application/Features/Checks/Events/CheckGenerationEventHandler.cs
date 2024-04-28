using EDA.Consumer.Demo.Application.Common.Interfaces;
using EDA.Consumer.Demo.Domain.Checks.Events;
using MediatR;

namespace EDA.Consumer.Demo.Application.Features.Checks.Events;

public class CheckGenerationEventHandler : INotificationHandler<CheckGeneration>
{
    private readonly ICheckRepository _checkRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CheckGenerationEventHandler(ICheckRepository checkRepository, IUnitOfWork unitOfWork)
    {
        _checkRepository = checkRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(CheckGeneration notification, CancellationToken cancellationToken)
    {
        var check = _checkRepository.GenerateCheckAsync(notification.Id);
        await _unitOfWork.CommitTransactionAsync();
    }
    
}