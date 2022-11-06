using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Services;

public interface IGracePeriodService
{
    Task<IEnumerable<GracePeriod>> ListAsync();
    Task<GracePeriodResponse> SaveAsync(GracePeriod graceperiod);
    Task<GracePeriod> FindByIdAsync(int id);
    Task<GracePeriodResponse> UpdateAsync(int id, GracePeriod graceperiod);
    Task<GracePeriodResponse> DeleteAsync(int id);
}