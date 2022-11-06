using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Services;
using AlpacaFinance.API.AlpacaFinance.Resources;
using AlpacaFinance.API.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlpacaFinance.API.AlpacaFinance.Controllers;

[Route("/api/v1/[controller]")]
public class RateTypeController : ControllerBase
{
    private readonly IRateTypeService _ratetypeService;
    private readonly IMapper _mapper;

    public RateTypeController(IRateTypeService ratetypeService, IMapper mapper)
    {
        _ratetypeService = ratetypeService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<RateTypeResource>> GetAllSync()
    {
        var ratetypes = await _ratetypeService.ListAsync();
            
        var resources = _mapper.Map<IEnumerable<RateType>, IEnumerable<RateTypeResource>>(ratetypes);
            
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<RateTypeResource> GetPersonById(int id)
    {
        var ratetype = await _ratetypeService.FindByIdAsync(id);
        
        var resource = _mapper.Map<RateType, RateTypeResource>(ratetype);
        
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveRateTypeResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var ratetype = _mapper.Map<SaveRateTypeResource, RateType>(resource);

        var result = await _ratetypeService.SaveAsync(ratetype);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var ratetypeResource = _mapper.Map<RateType, RateTypeResource>(result.Resource);

        return Ok(ratetypeResource);
    }
    
    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] SaveRateTypeResource resource, int id)
    {
        var ratetype = _mapper.Map<SaveRateTypeResource, RateType>(resource);
        
        var result = await _ratetypeService.UpdateAsync(id, ratetype);

        if (!result.Success)
            return BadRequest(result.Message);

        var ratetypeResource = _mapper.Map<RateType, RateTypeResource>(result.Resource);

        return Ok(ratetypeResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _ratetypeService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var resource = _mapper.Map<RateType, RateTypeResource>(result.Resource);
        
        return Ok(resource);
    }
}