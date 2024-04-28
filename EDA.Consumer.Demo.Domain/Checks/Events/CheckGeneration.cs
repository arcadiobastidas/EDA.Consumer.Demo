using EDA.Consumer.Demo.Domain.Common;

namespace EDA.Consumer.Demo.Domain.Checks.Events;

public record CheckGeneration(Guid Id) : IDomainEvent;