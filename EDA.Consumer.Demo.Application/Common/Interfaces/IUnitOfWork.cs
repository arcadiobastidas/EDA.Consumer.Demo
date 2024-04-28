namespace EDA.Consumer.Demo.Application.Common.Interfaces;

public interface IUnitOfWork
{
    Task CommitTransactionAsync();
    Task RevertTransactionAsync();
}