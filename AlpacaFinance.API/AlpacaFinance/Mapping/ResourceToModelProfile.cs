using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Resources;
using AutoMapper;

namespace AlpacaFinance.API.AlpacaFinance.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveUsuarioResource, Usuario>();
        CreateMap<SaveHistorialResource, Historial>();
        CreateMap<SaveOperacionResource, Operacion>();
        CreateMap<SaveDivisaResource, Divisa>();
        CreateMap<SaveCashFlowResource, CashFlow>();
        CreateMap<SaveRateTypeResource, RateType>();
        CreateMap<SaveGracePeriodResource, GracePeriod>();

    }
}