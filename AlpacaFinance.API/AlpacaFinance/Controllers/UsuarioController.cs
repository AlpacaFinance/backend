using AlpacaFinance.API.AlpacaFinance.Domain.Models;
using AlpacaFinance.API.AlpacaFinance.Domain.Services;
using AlpacaFinance.API.AlpacaFinance.Resources;
using AlpacaFinance.API.Shared.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlpacaFinance.API.AlpacaFinance.Controllers;

[Produces("application/json")]
[ApiController]
[Route("/api/v1/[controller]")]
public class UsuarioController: ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly IMapper _mapper;

    public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
    {
        _usuarioService = usuarioService;
        _mapper = mapper;
    }
    
    
    
    [HttpGet]
    public async Task<IEnumerable<UsuarioResource>> GetAllSync()
    {
        var usuarios = await _usuarioService.ListAsync();
            
        var resources = _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioResource>>(usuarios);
            
        return resources;
    }
    [HttpGet("{id}")]
    public async Task<UsuarioResource> GetUsuarioById(int id)
    {
        var usuario = await _usuarioService.FindByIdAsync(id);
        
        var resource = _mapper.Map<Usuario, UsuarioResource>(usuario);
        
        return resource;
    }

    [HttpPost("register")]
    public async Task<IActionResult> PostAsync([FromBody] SaveUsuarioResource resource)
    {
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var usuario = _mapper.Map<SaveUsuarioResource, Usuario>(resource);

        var result = await _usuarioService.SaveAsync(usuario);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var usuarioResource = _mapper.Map<Usuario, UsuarioResource>(result.Resource);

        return Ok(usuarioResource);
    }
    [HttpGet("login")]
    public async Task<IActionResult> LoginAsync([FromQuery] string email, string password)
    {

        var result = await _usuarioService.LoginAsync(email, password);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var resource = _mapper.Map<Usuario, UsuarioResource>(result.Resource);

        return Ok(resource);
    }
    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] SaveUsuarioResource resource, int id)
    {
        var usuario = _mapper.Map<SaveUsuarioResource, Usuario>(resource);
        
        var result = await _usuarioService.UpdateAsync(id, usuario);

        if (!result.Success)
            return BadRequest(result.Message);

        var usuarioResource = _mapper.Map<Usuario, UsuarioResource>(result.Resource);

        return Ok(usuarioResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _usuarioService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var resource = _mapper.Map<Usuario, UsuarioResource>(result.Resource);
        
        return Ok(resource);
    }
}