using Core.Application.Abstractions.Services.Setups;
using Core.Domain.Models.SetupModels;
using Microsoft.AspNetCore.Mvc;

namespace HazonApi.Controllers.Setups;
[ApiController]
[Route("api/[controller]/")]
public class ClientTypeController : ControllerBase
{
    private readonly IClientTypeService _clientType;
    public ClientTypeController(IClientTypeService service)
    {
        _clientType = service;
    }
    [HttpPost("add/new/client/type")]
    public async Task<IActionResult> AddNewClientType(ClientType clientType)
    {
        try
        {
            var type = await _clientType.CreateClientType(clientType);
            return Ok(type);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    [HttpPost("update/client/type/name")]
    public async Task<IActionResult> UpdateClientTypeName(Guid clientTypeId, string name)
    {
        try
        {
            var updateName = await _clientType.UpdateClientTypeName(clientTypeId, name);
            return Ok(updateName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    [HttpPost("update/client/type/description")]
    public async Task<IActionResult> UpdateClientTypeDescription(Guid clientTypeId, string description)
    {
        try
        {
            var descriptionUpdate = await _clientType.UpdateClientTypeDescription(clientTypeId, description);
            return Ok(descriptionUpdate);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    [HttpDelete("delete/client/type/by/{clientTypeId}")]
    public async Task<IActionResult> DeleteClientType(Guid clientTypeId)
    {
        try
        {
            var deletedType = await _clientType.DeleteClientType(clientTypeId);
            return Ok(deletedType);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    [HttpGet("get/lov/client/types")]
    public async Task<IActionResult> FetchClientTypesLovs()
    {
        try
        {
            var lov = await _clientType.ClientTypeLov();
            return Ok(lov);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}