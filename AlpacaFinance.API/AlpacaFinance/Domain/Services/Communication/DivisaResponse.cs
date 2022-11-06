using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.Shared.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

public class DivisaResponse : BaseResponse<Divisa>
{
    public DivisaResponse(Divisa resource) : base(resource)
    {
    }

    public DivisaResponse(string message) : base(message)
    {
    }
}