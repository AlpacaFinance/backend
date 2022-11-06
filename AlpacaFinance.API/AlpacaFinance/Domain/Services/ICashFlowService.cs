using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Services;

public interface ICashFlowService
{
    Task<IEnumerable<CashFlow>> ListAsync();
    Task<CashFlowResponse> SaveAsync(CashFlow cashflow);
    Task<CashFlow> FindByIdAsync(int id);
    Task<CashFlowResponse> UpdateAsync(int id, CashFlow cashflow);
    Task<CashFlowResponse> DeleteAsync(int id);
}