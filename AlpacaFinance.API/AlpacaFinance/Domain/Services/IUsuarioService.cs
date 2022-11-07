using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Services;

public interface IUsuarioService
{
    Task<UsuarioResponse> LoginAsync(string email, string password);
    Task<IEnumerable<Usuario>> ListAsync();
    Task<UsuarioResponse> SaveAsync(Usuario usuario);
    Task<Usuario> FindByIdAsync(int id);
    Task<UsuarioResponse> UpdateAsync(int id, Usuario usuario);
    Task<UsuarioResponse> DeleteAsync(int id);
}