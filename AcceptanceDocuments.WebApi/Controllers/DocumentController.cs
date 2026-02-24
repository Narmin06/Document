using AcceptanceDocuments.Business.DTOs;
using AcceptanceDocuments.Business.DTOs.DocumentDTO;
using AcceptanceDocuments.Business.DTOs.DocumentFieldValueDTO;
using AcceptanceDocuments.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AcceptanceDocuments.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] DocumentCreateRequestDTO documentDto, CancellationToken cancellationToken)
        {
            if (documentDto == null)
                return BadRequest("Invalid document data.");

            if (documentDto.File == null)
                return BadRequest("File is required.");

            if (!string.IsNullOrWhiteSpace(documentDto.FieldValueJson))
            {
                var fieldValues = JsonConvert.DeserializeObject<IEnumerable<DocumentFieldValueCreateRequestDTO>>(documentDto.FieldValueJson);
                documentDto.FieldValues = fieldValues?.ToList();
            }
            await _documentService.CreateAsync(documentDto, cancellationToken);
            return Ok(new { message = "Document created successfully." });
        }


        [HttpDelete("admin/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _documentService.DeleteAsync(id, cancellationToken);
            return Ok(new { message = "Document deleted successfully." });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromForm] DocumentUpdateRequestDTO documentDto, CancellationToken cancellationToken)
        {
            if (documentDto == null)
                return BadRequest("Invalid document data.");

            if (!string.IsNullOrWhiteSpace(documentDto.FieldValueJson))
            {
                var fieldValues = JsonConvert.DeserializeObject<IEnumerable<DocumentFieldValueCreateRequestDTO>>(documentDto.FieldValueJson);
                documentDto.FieldValues = fieldValues?.ToList();
            }

            await _documentService.UpdateAsync(id, documentDto, cancellationToken);
            return Ok(new { message = "Document updated successfully." });
        }


        [HttpGet("admin")]
        public async Task<IActionResult> GetAllAdminAsync([FromQuery] DocumentQueryDTO documentQuery, CancellationToken cancellationToken)
        {
            if (documentQuery == null)
                return BadRequest("Query parameters are missing.");

            var result = await _documentService.GetAllAsync(documentQuery, cancellationToken);
            return Ok(result);
        }


        [HttpGet("moderator")]
        public async Task<IActionResult> GetAllAsync([FromQuery] DocumentQueryDTO documentQuery, CancellationToken cancellationToken)
        {
            if (documentQuery == null)
                return BadRequest("Query parameters are missing.");

            var result = await _documentService.GetAllModeratorAsync(documentQuery, cancellationToken);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var document = await _documentService.GetByIdAsync(id, cancellationToken);
            return Ok(document);
        }


        [HttpPatch("softdelete/{id}")]
        public async Task<IActionResult> SoftDeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _documentService.SoftDeleteAsync(id, cancellationToken);
                return Ok(new { message = "Document soft deleted successfully." });
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
                await _documentService.RecoverAsync(id, cancellationToken);
                return Ok(new { message = "Document recovered successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPatch("activate/{id}")]
        public async Task<IActionResult> ActivateAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _documentService.ActivateAsync(id, cancellationToken);
                return Ok(new { message = "Document activated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPatch("deactivate/{id}")]
        public async Task<IActionResult> DeactivateAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _documentService.DeactivateAsync(id, cancellationToken);
                return Ok(new { message = "Document deactiavted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}