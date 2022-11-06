using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Services;
using AlpacaFinance.API.AlpacaFinance.Resources;
using AlpacaFinance.API.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlpacaFinance.API.AlpacaFinance.Controllers;

[Route("/api/v1/[controller]")]
public class CashFlowController : ControllerBase
{
    private readonly ICashFlowService _cashflowService;
    private readonly IMapper _mapper;

    public CashFlowController(ICashFlowService cashflowService, IMapper mapper)
    {
        _cashflowService = cashflowService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<CashFlowResource>> GetAllSync()
    {
        var cashflows = await _cashflowService.ListAsync();
            
        var resources = _mapper.Map<IEnumerable<CashFlow>, IEnumerable<CashFlowResource>>(cashflows);
            
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<CashFlowResource> GetPersonById(int id)
    {
        var cashflow = await _cashflowService.FindByIdAsync(id);
        
        var resource = _mapper.Map<CashFlow, CashFlowResource>(cashflow);
        
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCashFlowResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var cashflow = _mapper.Map<SaveCashFlowResource, CashFlow>(resource);

        var result = await _cashflowService.SaveAsync(cashflow);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var cashflowResource = _mapper.Map<CashFlow, CashFlowResource>(result.Resource);

        return Ok(cashflowResource);
    }
    
    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] SaveCashFlowResource resource, int id)
    {
        var cashflow = _mapper.Map<SaveCashFlowResource, CashFlow>(resource);
        
        var result = await _cashflowService.UpdateAsync(id, cashflow);

        if (!result.Success)
            return BadRequest(result.Message);

        var cashflowResource = _mapper.Map<CashFlow, CashFlowResource>(result.Resource);

        return Ok(cashflowResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _cashflowService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var resource = _mapper.Map<CashFlow, CashFlowResource>(result.Resource);
        
        return Ok(resource);
    }
}