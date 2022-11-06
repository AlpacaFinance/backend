using AlpacaFinance.API.AlpacaFinance.Domain.Models;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Repositories;

public interface IGracePeriodRepository
{
    Task<IEnumerable<GracePeriod>> ListAsync(); 
    Task AddAsync(GracePeriod graceperiod);
    Task<GracePeriod> FindByIdAsync(int id);
    void Update(GracePeriod graceperiod);
    void Remove(GracePeriod graceperiod);
}