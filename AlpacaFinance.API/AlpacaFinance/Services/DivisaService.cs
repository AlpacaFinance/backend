using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Repositories;
using AlpacaFinance.API.AlpacaFinance.Domain.Services;
using AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Services;

public class DivisaService : IDivisaService
{
    private readonly IDivisaRepository _divisaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DivisaService(IDivisaRepository divisaRepository, IUnitOfWork unitOfWork)
    {
        _divisaRepository = divisaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Divisa>> ListAsync()
    {
        return await _divisaRepository.ListAsync();
    }

    public async Task<DivisaResponse> SaveAsync(Divisa divisa)
    {
        try
        {
            await _divisaRepository.AddAsync(divisa);
            await _unitOfWork.CompleteAsync();

            return new DivisaResponse(divisa);
        }
        catch (Exception e)
        {
            return new DivisaResponse("An error occurred while saving an Divisa");
        }
    }

    public async Task<Divisa> FindByIdAsync(int id)
    {
        return await _divisaRepository.FindByIdAsync(id);
    }

    public async Task<DivisaResponse> UpdateAsync(int id, Divisa divisa)
    {
        var existingDivisa = await _divisaRepository.FindByIdAsync(id);
        
        if (existingDivisa == null)
            return new DivisaResponse("Invalid Divisa Id");

        _divisaRepository.Update(divisa);
        await _unitOfWork.CompleteAsync();

        return new DivisaResponse(existingDivisa);
    }

    public async Task<DivisaResponse> DeleteAsync(int id)
    {
        var existingDivisa = await _divisaRepository.FindByIdAsync(id);
        
        if (existingDivisa == null)
            return new DivisaResponse("Invalid Divisa Id");
        
        _divisaRepository.Remove(existingDivisa);
        await _unitOfWork.CompleteAsync();

        return new DivisaResponse(existingDivisa);
    }
}