using AlpacaFinance.API.AlpacaFinance.Domain.Models;

namespace AlpacaFinance.API.AlpacaFinance.Resources;

public class OperacionResource
{
    public int Id { get; set; }
    public decimal Percentage  { get; set; }
    public float Import { get; set; }
    public DateTime Date { get; set; }
    
    public Usuario Usuario { get; set; }
    public RateType RateType { get; set; }
    public Divisa Divisa { get; set; }
    public CashFlow CashFlow { get; set; }
    public GracePeriod GracePeriod { get; set; }
}