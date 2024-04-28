namespace EDA.Consumer.Demo.Application.Common.Interfaces;

public interface ICheckRepository
{
    Task GenerateCheckAsync(Guid id);
}