namespace AlpacaFinance.API.AlpacaFinance.Resources;

public class CashFlowResource
{
    public int Id { get; set; }
    public string ActivityType { get; set; }
    public float MonthlyFlow { get; set; }
    public string ActivityDescription { get; set; }
}