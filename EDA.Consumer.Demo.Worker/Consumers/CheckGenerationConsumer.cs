using Contracts;
using MassTransit;

namespace EDA.Consumer.Demo.Worker.Consumers
{
   public class CheckGenerationConsumer : IConsumer<CheckGeneration>
    {
        private readonly ILogger<CheckGenerationConsumer> _logger;
        
        public CheckGenerationConsumer(ILogger<CheckGenerationConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<CheckGeneration> context)
        {
            _logger.LogInformation("Received message: {Message}", context.Message.Id.ToString());
            return Task.CompletedTask;
        }
    }
}