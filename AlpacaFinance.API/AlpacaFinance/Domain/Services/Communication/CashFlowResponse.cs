using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.Shared.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

public class CashFlowResponse : BaseResponse<CashFlow>
{
    public CashFlowResponse(CashFlow resource) : base(resource)
    {
    }

    public CashFlowResponse(string message) : base(message)
    {
    }
}