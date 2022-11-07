using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Services;
using AlpacaFinance.API.AlpacaFinance.Resources;
using AlpacaFinance.API.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlpacaFinance.API.AlpacaFinance.Controllers;

[Route("/api/v1/[controller]")]
public class DivisaController : ControllerBase
{
    private readonly IDivisaService _divisaService;
    private readonly IMapper _mapper;

    public DivisaController(IDivisaService divisaService, IMapper mapper)
    {
        _divisaService = divisaService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<DivisaResource>> GetAllSync()
    {
        var divisas = await _divisaService.ListAsync();
            
        var resources = _mapper.Map<IEnumerable<Divisa>, IEnumerable<DivisaResource>>(divisas);
            
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<DivisaResource> GetPersonById(int id)
    {
        var divisa = await _divisaService.FindByIdAsync(id);
        
        var resource = _mapper.Map<Divisa, DivisaResource>(divisa);
        
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDivisaResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var divisa = _mapper.Map<SaveDivisaResource, Divisa>(resource);

        var result = await _divisaService.SaveAsync(divisa);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var divisaResource = _mapper.Map<Divisa, DivisaResource>(result.Resource);

        return Ok(divisaResource);
    }
    
    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] SaveDivisaResource resource, int id)
    {
        var divisa = _mapper.Map<SaveDivisaResource, Divisa>(resource);
        
        var result = await _divisaService.UpdateAsync(id, divisa);

        if (!result.Success)
            return BadRequest(result.Message);

        var divisaResource = _mapper.Map<Divisa, DivisaResource>(result.Resource);

        return Ok(divisaResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _divisaService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var resource = _mapper.Map<Divisa, DivisaResource>(result.Resource);
        
        return Ok(resource);
    }
}