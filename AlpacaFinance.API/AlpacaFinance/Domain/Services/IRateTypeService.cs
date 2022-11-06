using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Services;

public interface IRateTypeService
{
    Task<IEnumerable<RateType>> ListAsync();
    Task<RateTypeResponse> SaveAsync(RateType ratetype);
    Task<RateType> FindByIdAsync(int id);
    Task<RateTypeResponse> UpdateAsync(int id, RateType ratetype);
    Task<RateTypeResponse> DeleteAsync(int id);
}