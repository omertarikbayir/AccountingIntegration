using AccountingIntegration.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountingIntegration.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OcrController : ControllerBase
{
    private readonly IOcrService _ocrService;

    public OcrController(IOcrService ocrService)
    {
        _ocrService = ocrService;
    }

    [HttpPost("extract")]
    public IActionResult ExtractText([FromForm] IFormFile pdfFile)
    {
        if (pdfFile == null || pdfFile.Length == 0)
            return BadRequest("PDF dosyası gerekli.");

        using var stream = pdfFile.OpenReadStream();
        var text = _ocrService.ExtractTextFromPdf(stream);
        return Ok(new { ExtractedText = text });
    }
}