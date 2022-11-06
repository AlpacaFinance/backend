using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Repositories;
using AlpacaFinance.API.AlpacaFinance.Domain.Services;
using AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Services;

public class CashFlowService : ICashFlowService
{
    private readonly ICashFlowRepository _cashflowRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CashFlowService(ICashFlowRepository cashflowRepository, IUnitOfWork unitOfWork)
    {
        _cashflowRepository = cashflowRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CashFlow>> ListAsync()
    {
        return await _cashflowRepository.ListAsync();
    }

    public async Task<CashFlowResponse> SaveAsync(CashFlow cashflow)
    {
        try
        {
            await _cashflowRepository.AddAsync(cashflow);
            await _unitOfWork.CompleteAsync();

            return new CashFlowResponse(cashflow);
        }
        catch (Exception e)
        {
            return new CashFlowResponse("An error occurred while saving an CashFlow");
        }
    }

    public async Task<CashFlow> FindByIdAsync(int id)
    {
        return await _cashflowRepository.FindByIdAsync(id);
    }

    public async Task<CashFlowResponse> UpdateAsync(int id, CashFlow cashflow)
    {
        var existingCashFlow = await _cashflowRepository.FindByIdAsync(id);
        
        if (existingCashFlow == null)
            return new CashFlowResponse("Invalid CashFlow Id");

        _cashflowRepository.Update(cashflow);
        await _unitOfWork.CompleteAsync();

        return new CashFlowResponse(existingCashFlow);
    }

    public async Task<CashFlowResponse> DeleteAsync(int id)
    {
        var existingCashFlow = await _cashflowRepository.FindByIdAsync(id);
        
        if (existingCashFlow == null)
            return new CashFlowResponse("Invalid CashFlow Id");
        
        _cashflowRepository.Remove(existingCashFlow);
        await _unitOfWork.CompleteAsync();

        return new CashFlowResponse(existingCashFlow);
    }
}