using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Services;

public interface IDivisaService
{
    Task<IEnumerable<Divisa>> ListAsync();
    Task<DivisaResponse> SaveAsync(Divisa divisa);
    Task<Divisa> FindByIdAsync(int id);
    Task<DivisaResponse> UpdateAsync(int id, Divisa divisa);
    Task<DivisaResponse> DeleteAsync(int id);
}