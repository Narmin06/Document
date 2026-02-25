using AcceptanceDocuments.Business.DTOs.Common;
using AcceptanceDocuments.Business.DTOs.DocumentFieldDefinitionDTO;
using AcceptanceDocuments.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcceptanceDocuments.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentFieldDefinitionController : ControllerBase
{
    private readonly IDocumentFieldDefinitionService _documentFieldDefinitionService;

    public DocumentFieldDefinitionController(IDocumentFieldDefinitionService documentFieldDefinitionService)
    {
        _documentFieldDefinitionService = documentFieldDefinitionService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] DocumentFieldDefinitionCreateRequestDTO documentDto, CancellationToken cancellationToken)
    {
        if (documentDto == null)
            return BadRequest("Invalid document field definition data.");

        await _documentFieldDefinitionService.CreateAsync(documentDto, cancellationToken);
        return Ok(new { message = "Document field definition created successfully." });
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _documentFieldDefinitionService.DeleteAsync(id, cancellationToken);
            return Ok(new { message = "Document field definition deleted successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] DocumentFieldDefinitionUpdateRequestDTO documentDto, CancellationToken cancellationToken)
    {
        if (documentDto == null)
            return BadRequest("Invalid document field definition data.");

        await _documentFieldDefinitionService.UpdateAsync(id, documentDto, cancellationToken);
        return Ok(new { message = "Document field definition updated successfully." });
    }


    [HttpGet("admin")]
    public async Task<IActionResult> GetAllAdminAsync([FromQuery] BaseQueryDTO queryDto, CancellationToken cancellationToken)
    {
        if (queryDto == null)
            return BadRequest("Query parameters are missing.");

        var result = await _documentFieldDefinitionService.GetAllAsync(queryDto, cancellationToken);
        return Ok(result);
    }


    [HttpGet("moderator")]
    public async Task<IActionResult> GetAllModeratorAsync([FromQuery] BaseQueryDTO queryDto, CancellationToken cancellationToken)
    {
        if (queryDto == null)
            return BadRequest("Query parameters are missing.");

        var result = await _documentFieldDefinitionService.GetAllModeratorAsync(queryDto, cancellationToken);
        return Ok(result);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _documentFieldDefinitionService.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }


    [HttpPatch("softdelete/{id}")]
    public async Task<IActionResult> SoftDeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _documentFieldDefinitionService.SoftDeleteAsync(id, cancellationToken);
            return Ok(new { message = "Document field definition soft deleted successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }


    [HttpPatch("recover/{id}")]
    public async Task<IActionResult> RecoverAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _documentFieldDefinitionService.RecoverAsync(id, cancellationToken);
            return Ok(new { message = "Document field definition recovered successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}



