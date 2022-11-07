namespace AlpacaFinance.API.AlpacaFinance.Resources;

public class GracePeriodResource
{
    public int Id { get; set; }
    public DateTime Period { get; set; }
    public float InitialDebt { get; set; }
    public int MonthlyFactor { get; set; }
    public float PreviousDebt { get; set; }
    public float MonthlyPayment { get; set; }
    public float FinalDebt { get; set; }
}