using Core.Application.Abstractions.Services.Setups;

namespace HazonApi.Controllers.Setups;

[ApiController]
[Route("api/[controller]/")]
public class PolicyTypeController:ControllerBase
{
    private readonly IPolicyTypeService _policyType;
    private readonly ILogger _logger;

    public PolicyTypeController(IPolicyTypeService policyType, ILogger logger)
    {
        _policyType = policyType;
        _logger = logger;
    }

    [HttpGet("get/policy/type/by/{id}")]
    public async Task<IActionResult> GetPolicyTypeById(Guid policyTypeId){
        try
        {
         
        var policyType = _policyType.GetPolicyTypeById(policyTypeId);
        if (policyType == null)
        {
            return NotFound();
        }
        return Ok(policyType);   
        }
        catch (System.Exception)
        {
            
            _logger.LogError("Error in GetPolicyTypeById");
            return BadRequest();
        }
    }

    [HttpGet("get/all/policy/types")]
    public async Task<IActionResult> GetAllPolicyTypes(){
        try
        {
            var policies = await _policyType.GetAllPolicyTypes();
            if (policies == null) return BadRequest("Empty list! Try adding a policy type");
            
            return Ok(policies);
    }

    [HttpPost("create/policy/type")]
    public async Task<IActionResult> CreatePolicyType(PolicyType policyType){
        try
        {
            var exist = await _policyType.ExistAsync(policyType);
            if (exist != null) return BadRequest(exist);
            var newPolicyType = await _policyType.CreatePolicyType(policyType);
            if (newPolicyType == null) return BadRequest("Failed to create policy type");
            return Ok(newPolicyType);
        }
        catch (System.Exception)
        {
            _logger.LogError("Error in CreatePolicyType");
            return BadRequest();
        }
    }
    [HttpDelete("delete/policy/type/by/{policyTypeId}")]
    public async Task<IActionResult> DeletePolicyType(Guid policyTypeId){
        try
        {
            var deleted = await _policyType.DeletePolicyType(policyTypeId);
            if (deleted == false) return BadRequest("Failed to delete policy type");
            return Ok(deleted);
        }
        catch (System.Exception)
        {
            _logger.LogError("Error in DeletePolicyType");
            return BadRequest();
        }
    }
    [HttpPut("update/policy/type/name/{policyType}")]
    public async Task<IActionResult> UpdatePolicyType(string policyType){
        try
        {
            var updated = await _policyType.UpdatePolicyTypeName(policyType);
            if (updated == null) return BadRequest("Failed to update policy type");
            return Ok(updated);
        }
        catch (System.Exception)
        {
            _logger.LogError("Error in UpdatePolicyType");
            return BadRequest();
        }
    }
    [HttpPut("update/policy/type/description/{description}")]
    public async Task<IActionResult> UpdatePolicyTypeDescription(string description){
        try
        {
            var updated = await _policyType.UpdatePolicyTypeDescription(description);
            if (updated == null) return BadRequest("Failed to update policy type");
            return Ok(updated);
        }
        catch (System.Exception)
        {
            _logger.LogError("Error in UpdatePolicyTypeDescription");
            return BadRequest();
        }
    }
       [HttpPut("update/policy/type/rate/{rate}")]
       public async Task<IActionResult> UpdatePolicyTypeRate(decimal rate){
        try
        {
            var updated = await _policyType.UpdatePolicyTypeRate(rate);
            if (updated == null) return BadRequest("Failed to update policy type");
            return Ok(updated);
        }
        catch (System.Exception)
        {
            _logger.LogError("Error in UpdatePolicyTypeRate");
            return BadRequest();
        }
    
}