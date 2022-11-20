using AlpacaFinance.API.AlpacaFinance.Domain.Models;

namespace AlpacaFinance.API.AlpacaFinance.Resources;

public class OperacionResource
{
    public int Id { get; set; }
    public decimal Percentage  { get; set; }
    public float Import { get; set; }
    public DateTime Date { get; set; }

    public UsuarioResource Usuario { get; set; }
    public RateTypeResource RateType { get; set; }
    public DivisaResource Divisa { get; set; }
    public CashFlowResource CashFlow { get; set; }
    public GracePeriodResource GracePeriod { get; set; }
}
