using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Repositories;
using AlpacaFinance.API.AlpacaFinance.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AlpacaFinance.API.AlpacaFinance.Persistence.Repositories;

public class UsuarioRepository : BaseRepository, IUsuarioRepository
{
    public UsuarioRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Usuario> LoginAsync(string email, string password)
    {
        return await _context.Usuarios.Where(p => p.Email == email &&  p.Password == password).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Usuario>> ListAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task AddAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
    }

    public async Task<Usuario> FindByIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public void Update(Usuario usuario)
    {
        _context.Update(usuario);
    }

    public void Remove(Usuario usuario)
    {
        _context.Remove(usuario);
    }
}