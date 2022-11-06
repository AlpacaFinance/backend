using AlpacaFinance.API.AlpacaFinance.Domain.Models;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario> LoginAsync(string email, string password);
    Task<IEnumerable<Usuario>> ListAsync();
    Task AddAsync(Usuario person);
    Task<Usuario> FindByIdAsync(int id);
    void Update(Usuario person);
    void Remove(Usuario person);
}