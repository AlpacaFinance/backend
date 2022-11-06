using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.Shared.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

public class UsuarioResponse  : BaseResponse<Usuario>
{
    public UsuarioResponse(Usuario resource) : base(resource)
    {
    }

    public UsuarioResponse(string message) : base(message)
    {
    }
}