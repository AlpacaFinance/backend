namespace AlpacaFinance.API.AlpacaFinance.Domain.Models;

public class Historial
{
    public int Id { get; set; }

    public int OperacionId { get; set; }
    public Operacion Operacion { get; set; }
    
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}