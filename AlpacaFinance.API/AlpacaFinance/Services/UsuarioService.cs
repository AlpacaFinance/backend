using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Repositories;
using AlpacaFinance.API.AlpacaFinance.Domain.Services;
using AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UsuarioService(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<UsuarioResponse> LoginAsync(string email, string password)
    {
        try
        {
            var usuario = await _usuarioRepository.LoginAsync(email, password);
            if (usuario.Equals(null))
            {
                return new UsuarioResponse("Invalid Credentials");
            }
            return new UsuarioResponse(usuario);
        }
        catch (Exception e)
        {
            return new UsuarioResponse("Invalid Credentials"); 
        }
        
    }

    public async Task<IEnumerable<Usuario>> ListAsync()
    {
        return await _usuarioRepository.ListAsync();
    }

    public async Task<UsuarioResponse> SaveAsync(Usuario usuario)
    {
        try
        {
            await _usuarioRepository.AddAsync(usuario);
            await _unitOfWork.CompleteAsync();

            return new UsuarioResponse(usuario);
        }
        catch (Exception e)
        {
            return new UsuarioResponse("An error occurred while saving an Usuario");
        }
    }

    public async Task<Usuario> FindByIdAsync(int id)
    {
        return await _usuarioRepository.FindByIdAsync(id);
    }

    public async Task<UsuarioResponse> UpdateAsync(int id, Usuario usuario)
    {
        var existingUsuario = await _usuarioRepository.FindByIdAsync(id);
        
        if (existingUsuario == null)
            return new UsuarioResponse("Invalid Usuario Id");
        
        _usuarioRepository.Update(usuario);
        await _unitOfWork.CompleteAsync();

        return new UsuarioResponse(usuario);
    }

    public async Task<UsuarioResponse> DeleteAsync(int id)
    {
        var existingUsuario = await _usuarioRepository.FindByIdAsync(id);
        
        if (existingUsuario == null)
            return new UsuarioResponse("Invalid Usuario Id");
        
        _usuarioRepository.Remove(existingUsuario);
        await _unitOfWork.CompleteAsync();

        return new UsuarioResponse(existingUsuario);
    }
}