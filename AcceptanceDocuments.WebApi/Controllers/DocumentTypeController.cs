using AcceptanceDocuments.Business.DTOs.DocumentTypeDTO;
using AcceptanceDocuments.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcceptanceDocuments.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentTypeController : ControllerBase
{
    private readonly IDocumentTypeService _documentTypeService;

    public DocumentTypeController(IDocumentTypeService documentTypeService)
    {
        _documentTypeService = documentTypeService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] DocumentTypeCreateRequestDTO documentTypeDto, CancellationToken cancellationToken = default)
    {
        if (documentTypeDto == null)
            return BadRequest("Invalid document type data");

        await _documentTypeService.CreateAsync(documentTypeDto, cancellationToken);
        return Ok(new { message = "Document Type created successfully." });
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _documentTypeService.DeleteAsync(id, cancellationToken);
        return Ok(new { message = "Document Type deleted successfully." });
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] DocumentTypeUpdateRequestDTO documentTypeDto, CancellationToken cancellationToken)
    {
        if (documentTypeDto == null)
            return BadRequest("Invalid document type data");

        await _documentTypeService.UpdateAsync(id, documentTypeDto, cancellationToken);
        return Ok(new { message = "Document Type updated successfully." });
    }


    [HttpGet("admin")]
    public async Task<IActionResult> GetAllAsync([FromQuery] DocumentTypeQueryDTO queryDto, CancellationToken cancellationToken)
    {
        if (queryDto == null)
            return BadRequest("Invalid query parameters");

        var result = await _documentTypeService.GetAllAsync(queryDto, cancellationToken);
        return Ok(result);
    }


    [HttpGet("moderator")]
    public async Task<IActionResult> GetAllModeratorAsync([FromQuery] DocumentTypeQueryDTO queryDto, CancellationToken cancellationToken)
    {
        if (queryDto == null)
            return BadRequest("Invalid query parameters");

        var result = await _documentTypeService.GetAllModeratorAsync(queryDto, cancellationToken);
        return Ok(result);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _documentTypeService.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }


    [HttpPatch("softdelete/{id}")]
    public async Task<IActionResult> SoftDeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _documentTypeService.SoftDeleteAsync(id, cancellationToken);
            return Ok(new { message = "Document Type soft deleted successfully." });
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }


    [HttpPatch("recover/{id}")]
    public async Task<IActionResult> RecoverAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _documentTypeService.RecoverAsync(id, cancellationToken);
            return Ok(new { message = "Document Type recovered successfully." });
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}