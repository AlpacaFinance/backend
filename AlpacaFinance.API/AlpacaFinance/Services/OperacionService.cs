using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Repositories;
using AlpacaFinance.API.AlpacaFinance.Domain.Services;
using AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Services;

public class OperacionService : IOperacionService
{
    private readonly IOperacionRepository _operacionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OperacionService(IOperacionRepository operacionRepository, IUnitOfWork unitOfWork)
    {
        _operacionRepository = operacionRepository;
        _unitOfWork = unitOfWork;
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