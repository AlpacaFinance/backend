using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Repositories;
using AlpacaFinance.API.AlpacaFinance.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AlpacaFinance.API.AlpacaFinance.Persistence.Repositories;

public class RateTypeRepository: BaseRepository, IRateTypeRepository
{
    public RateTypeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<RateType>> ListAsync()
    {
        return await _context.RateTypes.ToListAsync();

    }

    public async Task AddAsync(RateType ratetype)
    {
        await _context.RateTypes.AddAsync(ratetype);
    }

    public async Task<RateType> FindByIdAsync(int id)
    {
        return await _context.RateTypes.FindAsync(id);
    }

    public void Update(RateType ratetype)
    {
        _context.RateTypes.Update(ratetype);
    }

    public void Remove(RateType ratetype)
    {
        _context.RateTypes.Remove(ratetype);
    }
}