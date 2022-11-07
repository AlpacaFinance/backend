namespace AlpacaFinance.API.AlpacaFinance.Resources;

public class SaveCashFlowResource
{
    public string ActivityType { get; set; }
    public float MonthlyFlow { get; set; }
    public string ActivityDescription { get; set; }
}