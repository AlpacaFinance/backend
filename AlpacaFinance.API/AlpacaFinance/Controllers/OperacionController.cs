using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Services;
using AlpacaFinance.API.AlpacaFinance.Resources;
using AlpacaFinance.API.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlpacaFinance.API.AlpacaFinance.Controllers;

[Route("/api/v1/[controller]")]
public class OperacionController : ControllerBase
{
    private readonly IOperacionService _operacionService;
    private readonly IMapper _mapper;

    public OperacionController(IOperacionService operacionService, IMapper mapper)
    {
        _operacionService = operacionService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<OperacionResource>> GetAllSync()
    {
        var operacions = await _operacionService.ListAsync();
            
        var resources = _mapper.Map<IEnumerable<Operacion>, IEnumerable<OperacionResource>>(operacions);
            
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<OperacionResource> GetPersonById(int id)
    {
        var operacion = await _operacionService.FindByIdAsync(id);
        
        var resource = _mapper.Map<Operacion, OperacionResource>(operacion);
        
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveOperacionResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var operacion = _mapper.Map<SaveOperacionResource, Operacion>(resource);

        var result = await _operacionService.SaveAsync(operacion);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var operacionResource = _mapper.Map<Operacion, OperacionResource>(result.Resource);

        return Ok(operacionResource);
    }
    
    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] SaveOperacionResource resource, int id)
    {
        var operacion = _mapper.Map<SaveOperacionResource, Operacion>(resource);
        
        var result = await _operacionService.UpdateAsync(id, operacion);

        if (!result.Success)
            return BadRequest(result.Message);

        var operacionResource = _mapper.Map<Operacion, OperacionResource>(result.Resource);

        return Ok(operacionResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _operacionService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var resource = _mapper.Map<Operacion, OperacionResource>(result.Resource);
        
        return Ok(resource);
    }
}