using AlpacaFinance.API.AlpacaFinance.Domain.Models;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Repositories;

public interface ICashFlowRepository
{
    Task<IEnumerable<CashFlow>> ListAsync(); 
    Task AddAsync(CashFlow cashflow);
    Task<CashFlow> FindByIdAsync(int id);
    void Update(CashFlow cashflow);
    void Remove(CashFlow cashflow);
}