using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Services;
using AlpacaFinance.API.AlpacaFinance.Resources;
using AlpacaFinance.API.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlpacaFinance.API.AlpacaFinance.Controllers;

[Route("/api/v1/[controller]")]
public class GracePeriodController : ControllerBase
{
    private readonly IGracePeriodService _graceperiodService;
    private readonly IMapper _mapper;

    public GracePeriodController(IGracePeriodService graceperiodService, IMapper mapper)
    {
        _graceperiodService = graceperiodService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<GracePeriodResource>> GetAllSync()
    {
        var graceperiods = await _graceperiodService.ListAsync();
            
        var resources = _mapper.Map<IEnumerable<GracePeriod>, IEnumerable<GracePeriodResource>>(graceperiods);
            
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<GracePeriodResource> GetPersonById(int id)
    {
        var graceperiod = await _graceperiodService.FindByIdAsync(id);
        
        var resource = _mapper.Map<GracePeriod, GracePeriodResource>(graceperiod);
        
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveGracePeriodResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var graceperiod = _mapper.Map<SaveGracePeriodResource, GracePeriod>(resource);

        var result = await _graceperiodService.SaveAsync(graceperiod);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var graceperiodResource = _mapper.Map<GracePeriod, GracePeriodResource>(result.Resource);

        return Ok(graceperiodResource);
    }
    
    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] SaveGracePeriodResource resource, int id)
    {
        var graceperiod = _mapper.Map<SaveGracePeriodResource, GracePeriod>(resource);
        
        var result = await _graceperiodService.UpdateAsync(id, graceperiod);

        if (!result.Success)
            return BadRequest(result.Message);

        var graceperiodResource = _mapper.Map<GracePeriod, GracePeriodResource>(result.Resource);

        return Ok(graceperiodResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _graceperiodService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var resource = _mapper.Map<GracePeriod, GracePeriodResource>(result.Resource);
        
        return Ok(resource);
    }
}