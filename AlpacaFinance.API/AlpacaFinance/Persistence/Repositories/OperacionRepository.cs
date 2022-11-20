using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Repositories;
using AlpacaFinance.API.AlpacaFinance.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AlpacaFinance.API.AlpacaFinance.Persistence.Repositories;

public class OperacionRepository: BaseRepository, IOperacionRepository
{
    public OperacionRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Operacion>> ListAsync()
    {
        return await _context.Operacions
            .Include(p=>p.Usuario)
            .Include(p=>p.RateType)
            .Include(p=>p.Divisa)
            .Include(p=>p.CashFlow)
            .Include(p=>p.GracePeriod)
            .ToListAsync();

    }

    public async Task AddAsync(Operacion operacion)
    {
        await _context.Operacions.AddAsync(operacion);
    }

    public async Task<Operacion> FindByIdAsync(int id)
    {
        return await _context.Operacions
            .Include(p=>p.Usuario)
            .Include(p=>p.RateType)
            .Include(p=>p.Divisa)
            .Include(p=>p.CashFlow)
            .Include(p=>p.GracePeriod)
            .FirstOrDefaultAsync(p=>p.Id==id);
    }

    public void Update(Operacion operacion)
    {
        _context.Operacions.Update(operacion);
    }

    public void Remove(Operacion operacion)
    {
        _context.Operacions.Remove(operacion);
    }
}
