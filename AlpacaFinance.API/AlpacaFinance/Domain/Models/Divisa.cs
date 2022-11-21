namespace AlpacaFinance.API.AlpacaFinance.Domain.Models;

public class Divisa
{
    public int Id { get; set; }
    public string NameDivisa { get; set; }
    
    public Operacion Operacion { get; set; }
    
    public IList<Operacion> OperacionDivisa { get; set; } = new List<Operacion>();
}