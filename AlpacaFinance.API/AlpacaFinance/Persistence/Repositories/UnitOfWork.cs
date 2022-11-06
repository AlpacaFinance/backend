using AlpacaFinance.API.AlpacaFinance.Domain.Repositories;
using AlpacaFinance.API.AlpacaFinance.Persistence.Contexts;

namespace AlpacaFinance.API.AlpacaFinance.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}