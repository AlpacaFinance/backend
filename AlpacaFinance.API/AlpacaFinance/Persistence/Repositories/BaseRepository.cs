using AlpacaFinance.API.AlpacaFinance.Persistence.Contexts;

namespace AlpacaFinance.API.AlpacaFinance.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}