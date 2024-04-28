using EDA.Consumer.Demo.Domain.Checks.Events;
using Eda.Demo.Messaging.Contracts.Outbound;
using MassTransit;
using MediatR;

namespace EDA.Consumer.Demo.Worker.Consumers
{
   public class CheckGenerationRequestedConsumer : IConsumer<CheckGenerationRequested>
    {
        private readonly ILogger<CheckGenerationRequestedConsumer> _logger;
        private readonly IMediator _mediator;
        
        public CheckGenerationRequestedConsumer(ILogger<CheckGenerationRequestedConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        public Task Consume(ConsumeContext<CheckGenerationRequested> context)
        {
            _logger.LogInformation("Received message: {Message}", context.Message.Id.ToString());
             _mediator.Publish(new CheckGeneration(context.Message.Id));
            return Task.CompletedTask;
        }
    }
}