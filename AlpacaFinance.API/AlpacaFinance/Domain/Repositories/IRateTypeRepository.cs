using AlpacaFinance.API.AlpacaFinance.Domain.Models;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Repositories;

public interface IRateTypeRepository
{
    Task<IEnumerable<RateType>> ListAsync(); 
    Task AddAsync(RateType ratetype);
    Task<RateType> FindByIdAsync(int id);
    void Update(RateType ratetype);
    void Remove(RateType ratetype);
}