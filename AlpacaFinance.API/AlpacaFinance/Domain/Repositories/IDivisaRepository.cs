using AlpacaFinance.API.AlpacaFinance.Domain.Models;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Repositories;

public interface IDivisaRepository
{
    Task<IEnumerable<Divisa>> ListAsync(); 
    Task AddAsync(Divisa divisa);
    Task<Divisa> FindByIdAsync(int id);
    void Update(Divisa divisa);
    void Remove(Divisa divisa);
}