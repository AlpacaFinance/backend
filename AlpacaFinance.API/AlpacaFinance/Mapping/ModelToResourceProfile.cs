using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Resources;
using AutoMapper;

namespace AlpacaFinance.API.AlpacaFinance.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Usuario, UsuarioResource>();
        CreateMap<Operacion, OperacionResource>();
        CreateMap<Divisa, DivisaResource>();
        CreateMap<CashFlow, CashFlowResource>();
        CreateMap<RateType, RateTypeResource>();
        CreateMap<GracePeriod, GracePeriodResource>();

    }
}