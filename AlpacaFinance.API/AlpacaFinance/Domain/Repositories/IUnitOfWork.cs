namespace AlpacaFinance.API.AlpacaFinance.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}