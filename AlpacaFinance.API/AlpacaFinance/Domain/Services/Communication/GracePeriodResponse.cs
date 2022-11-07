using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.Shared.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

public class GracePeriodResponse : BaseResponse<GracePeriod>
{
    public GracePeriodResponse(GracePeriod resource) : base(resource)
    {
    }

    public GracePeriodResponse(string message) : base(message)
    {
    }
}