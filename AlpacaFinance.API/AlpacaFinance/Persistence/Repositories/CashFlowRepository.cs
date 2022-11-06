using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Repositories;
using AlpacaFinance.API.AlpacaFinance.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AlpacaFinance.API.AlpacaFinance.Persistence.Repositories;

public class CashFlowRepository: BaseRepository, ICashFlowRepository
{
    public CashFlowRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CashFlow>> ListAsync()
    {
        return await _context.CashFlows.ToListAsync();

    }

    public async Task AddAsync(CashFlow cashflow)
    {
        await _context.CashFlows.AddAsync(cashflow);
    }

    public async Task<CashFlow> FindByIdAsync(int id)
    {
        return await _context.CashFlows.FindAsync(id);
    }

    public void Update(CashFlow cashflow)
    {
        _context.CashFlows.Update(cashflow);
    }

    public void Remove(CashFlow cashflow)
    {
        _context.CashFlows.Remove(cashflow);
    }
}