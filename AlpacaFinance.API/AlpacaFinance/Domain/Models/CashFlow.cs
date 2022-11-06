namespace AlpacaFinance.API.AlpacaFinance.Domain.Models;

public class CashFlow
{
    public int Id { get; set; }
    public string ActivityType { get; set; }
    public float MonthlyFlow { get; set; }
    public string ActivityDescription { get; set; }
    
    public IList<Operacion> Operacions { get; set; } = new List<Operacion>();
    
}