namespace AlpacaFinance.API.AlpacaFinance.Domain.Models;

public class Operacion
{
    public int Id { get; set; }
    public decimal Percentage  { get; set; }
    public float Import { get; set; }
    public DateTime Date { get; set; }
    
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    
    public int RateTypeId { get; set; }
    public RateType RateType { get; set; }
    
    public int DivisaId { get; set; }
    public Divisa Divisa { get; set; }
    
    public int CashFlowId { get; set; }
    public CashFlow CashFlow { get; set; }
    
    public int GracePeriodId { get; set; }
    public GracePeriod GracePeriod { get; set; }
    
}