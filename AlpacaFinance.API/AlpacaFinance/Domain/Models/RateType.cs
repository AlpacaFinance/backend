namespace AlpacaFinance.API.AlpacaFinance.Domain.Models;

public class RateType
{
    public int Id { get; set; }
    public string NameType { get; set; }
    
    public IList<Operacion> Operacions { get; set; } = new List<Operacion>();
    
    public IList<Operacion> OperacionRateType { get; set; } = new List<Operacion>();
    
}