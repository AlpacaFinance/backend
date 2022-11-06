using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.Shared.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

public class OperacionResponse : BaseResponse<Operacion>
{
    public OperacionResponse(Operacion resource) : base(resource)
    {
    }

    public OperacionResponse(string message) : base(message)
    {
    }
}