using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.Shared.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

public class RateTypeResponse : BaseResponse<RateType>
{
    public RateTypeResponse(RateType resource) : base(resource)
    {
    }

    public RateTypeResponse(string message) : base(message)
    {
    }
}