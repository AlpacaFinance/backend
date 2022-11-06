using AlpacaFinance.API.AlpacaFinance.Domain.Models;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Repositories;

public interface IOperacionRepository
{
    Task<IEnumerable<Operacion>> ListAsync(); 
    Task AddAsync(Operacion operacion);
    Task<Operacion> FindByIdAsync(int id);
    void Update(Operacion operacion);
    void Remove(Operacion operacion);
}