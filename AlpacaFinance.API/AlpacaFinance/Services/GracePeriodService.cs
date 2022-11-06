using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Repositories;
using AlpacaFinance.API.AlpacaFinance.Domain.Services;
using AlpacaFinance.API.AlpacaFinance.Domain.Services.Communication;

namespace AlpacaFinance.API.AlpacaFinance.Services;

public class GracePeriodService : IGracePeriodService
{
    private readonly IGracePeriodRepository _graceperiodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GracePeriodService(IGracePeriodRepository graceperiodRepository, IUnitOfWork unitOfWork)
    {
        _graceperiodRepository = graceperiodRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<GracePeriod>> ListAsync()
    {
        return await _graceperiodRepository.ListAsync();
    }

    public async Task<GracePeriodResponse> SaveAsync(GracePeriod graceperiod)
    {
        try
        {
            await _graceperiodRepository.AddAsync(graceperiod);
            await _unitOfWork.CompleteAsync();

            return new GracePeriodResponse(graceperiod);
        }
        catch (Exception e)
        {
            return new GracePeriodResponse("An error occurred while saving an GracePeriod");
        }
    }

    public async Task<GracePeriod> FindByIdAsync(int id)
    {
        return await _graceperiodRepository.FindByIdAsync(id);
    }

    public async Task<GracePeriodResponse> UpdateAsync(int id, GracePeriod graceperiod)
    {
        var existingGracePeriod = await _graceperiodRepository.FindByIdAsync(id);
        
        if (existingGracePeriod == null)
            return new GracePeriodResponse("Invalid GracePeriod Id");

        _graceperiodRepository.Update(graceperiod);
        await _unitOfWork.CompleteAsync();

        return new GracePeriodResponse(existingGracePeriod);
    }

    public async Task<GracePeriodResponse> DeleteAsync(int id)
    {
        var existingGracePeriod = await _graceperiodRepository.FindByIdAsync(id);
        
        if (existingGracePeriod == null)
            return new GracePeriodResponse("Invalid GracePeriod Id");
        
        _graceperiodRepository.Remove(existingGracePeriod);
        await _unitOfWork.CompleteAsync();

        return new GracePeriodResponse(existingGracePeriod);
    }
}