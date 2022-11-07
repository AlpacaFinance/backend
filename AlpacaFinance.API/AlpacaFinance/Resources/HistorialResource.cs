using AlpacaFinance.API.AlpacaFinance.Domain.Models;

namespace AlpacaFinance.API.AlpacaFinance.Resources;

public class HistorialResource
{
    public int Id { get; set; }
    
    public Operacion Operacion { get; set; }
    public Usuario Usuario { get; set; }
}