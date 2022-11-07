using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Services;

public interface IOperacionService
{
    Task<IEnumerable<Operacion>> ListAsync();
    Task<OperacionResponse> SaveAsync(Operacion operacion);
    Task<Operacion> FindByIdAsync(int id);
    Task<OperacionResponse> UpdateAsync(int id, Operacion operacion);
    Task<OperacionResponse> DeleteAsync(int id);
}