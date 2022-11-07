namespace AlpacaFinance.API.AlpacaFinance.Resources;

public class SaveOperacionResource
{
    public decimal Percentage  { get; set; }
    public float Import { get; set; }
    public DateTime Date { get; set; }

    public int UsuarioId { get; set; }
    public int RateTypeId { get; set; }
    public int DivisaId { get; set; }
    public int CashFlowId { get; set; }
    public int GracePeriodId { get; set; }
}