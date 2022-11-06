using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Repositories;
using AlpacaFinance.API.AlpacaFinance.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AlpacaFinance.API.AlpacaFinance.Persistence.Repositories;

public class GracePeriodRepository: BaseRepository, IGracePeriodRepository
{
    public GracePeriodRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<GracePeriod>> ListAsync()
    {
        return await _context.GracePeriods.ToListAsync();

    }

    public async Task AddAsync(GracePeriod graceperiod)
    {
        await _context.GracePeriods.AddAsync(graceperiod);
    }

    public async Task<GracePeriod> FindByIdAsync(int id)
    {
        return await _context.GracePeriods.FindAsync(id);
    }

    public void Update(GracePeriod graceperiod)
    {
        _context.GracePeriods.Update(graceperiod);
    }

    public void Remove(GracePeriod graceperiod)
    {
        _context.GracePeriods.Remove(graceperiod);
    }
}