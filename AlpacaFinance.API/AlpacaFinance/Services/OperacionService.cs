using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Repositories;
using AlpacaFinance.API.AlpacaFinance.Domain.Services;
using AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Services;

public class OperacionService : IOperacionService
{
    private readonly IOperacionRepository _operacionRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IRateTypeRepository _rateTypeRepository;
    private readonly IDivisaRepository _divisaRepository;
    private readonly ICashFlowRepository _cashFlowRepository;
    private readonly IGracePeriodRepository _gracePeriodRepository;

    public OperacionService(IOperacionRepository operacionRepository, IUnitOfWork unitOfWork,
        IUsuarioRepository usuarioRepository, IRateTypeRepository rateTypeRepository, IDivisaRepository divisaRepository,
        ICashFlowRepository cashFlowRepository, IGracePeriodRepository gracePeriodRepository)
    {
        _operacionRepository = operacionRepository;
        _unitOfWork = unitOfWork;
        _usuarioRepository = usuarioRepository;
        _rateTypeRepository = rateTypeRepository;
        _divisaRepository = divisaRepository;
        _cashFlowRepository = cashFlowRepository;
        _gracePeriodRepository = gracePeriodRepository;
    }

    public async Task<IEnumerable<Operacion>> ListAsync()
    {
        return await _operacionRepository.ListAsync();
    }

    public async Task<OperacionResponse> SaveAsync(Operacion operacion)
    {
        try
        {
            await _operacionRepository.AddAsync(operacion);
            await _unitOfWork.CompleteAsync();

            return new OperacionResponse(operacion);
        }
        catch (Exception e)
        {
            return new OperacionResponse("An error occurred while saving an Operacion");
        }
    }

    public async Task<Operacion> FindByIdAsync(int id)
    {
        return await _operacionRepository.FindByIdAsync(id);
    }
    
    public async Task<IEnumerable<Operacion>> ListByUsuarioId(int usuarioId)
    {
        return await _operacionRepository.FindByUsuarioId(usuarioId);
    }

    public async Task<OperacionResponse> UpdateAsync(int id, Operacion operacion)
    {
        var existingOperacion = await _operacionRepository.FindByIdAsync(id);
        
        if (existingOperacion == null)
            return new OperacionResponse("Invalid Operacion Id");

        _operacionRepository.Update(operacion);
        await _unitOfWork.CompleteAsync();

        return new OperacionResponse(existingOperacion);
    }

    public async Task<OperacionResponse> DeleteAsync(int id)
    {
        var existingOperacion = await _operacionRepository.FindByIdAsync(id);
        
        if (existingOperacion == null)
            return new OperacionResponse("Invalid Operacion Id");
        
        _operacionRepository.Remove(existingOperacion);
        await _unitOfWork.CompleteAsync();

        return new OperacionResponse(existingOperacion);
    }
}