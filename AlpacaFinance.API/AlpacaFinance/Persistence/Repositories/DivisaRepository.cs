using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Repositories;
using AlpacaFinance.API.AlpacaFinance.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AlpacaFinance.API.AlpacaFinance.Persistence.Repositories;

public class DivisaRepository: BaseRepository, IDivisaRepository
{
    public DivisaRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Divisa>> ListAsync()
    {
        return await _context.Divisas.ToListAsync();

    }

    public async Task AddAsync(Divisa divisa)
    {
        await _context.Divisas.AddAsync(divisa);
    }

    public async Task<Divisa> FindByIdAsync(int id)
    {
        return await _context.Divisas.FindAsync(id);
    }

    public void Update(Divisa divisa)
    {
        _context.Divisas.Update(divisa);
    }

    public void Remove(Divisa divisa)
    {
        _context.Divisas.Remove(divisa);
    }
}