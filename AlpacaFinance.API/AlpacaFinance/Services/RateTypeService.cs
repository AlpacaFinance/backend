using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Repositories;
using AlpacaFinance.API.AlpacaFinance.Domain.Services;
using AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Services;

public class RateTypeService : IRateTypeService
{
    private readonly IRateTypeRepository _ratetypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RateTypeService(IRateTypeRepository ratetypeRepository, IUnitOfWork unitOfWork)
    {
        _ratetypeRepository = ratetypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RateType>> ListAsync()
    {
        return await _ratetypeRepository.ListAsync();
    }

    public async Task<RateTypeResponse> SaveAsync(RateType ratetype)
    {
        try
        {
            await _ratetypeRepository.AddAsync(ratetype);
            await _unitOfWork.CompleteAsync();

            return new RateTypeResponse(ratetype);
        }
        catch (Exception e)
        {
            return new RateTypeResponse("An error occurred while saving an RateType");
        }
    }

    public async Task<RateType> FindByIdAsync(int id)
    {
        return await _ratetypeRepository.FindByIdAsync(id);
    }

    public async Task<RateTypeResponse> UpdateAsync(int id, RateType ratetype)
    {
        var existingRateType = await _ratetypeRepository.FindByIdAsync(id);
        
        if (existingRateType == null)
            return new RateTypeResponse("Invalid RateType Id");

        _ratetypeRepository.Update(ratetype);
        await _unitOfWork.CompleteAsync();

        return new RateTypeResponse(existingRateType);
    }

    public async Task<RateTypeResponse> DeleteAsync(int id)
    {
        var existingRateType = await _ratetypeRepository.FindByIdAsync(id);
        
        if (existingRateType == null)
            return new RateTypeResponse("Invalid RateType Id");
        
        _ratetypeRepository.Remove(existingRateType);
        await _unitOfWork.CompleteAsync();

        return new RateTypeResponse(existingRateType);
    }
}