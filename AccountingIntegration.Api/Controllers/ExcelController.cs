using AccountingIntegration.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AccountingIntegration.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExcelController : ControllerBase
{
    private readonly IExcelService _excelService;

    public ExcelController(IExcelService excelService)
    {
        _excelService = excelService;
    }

    [HttpPost("import")]
    public IActionResult Import([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Dosya yüklenmedi.");

        using var stream = file.OpenReadStream();
        var dataTable = _excelService.ImportExcel(stream);

        if (!_excelService.ValidateExcel(dataTable, out var errors))
            return BadRequest(errors);

        return Ok(dataTable);
    }

    [HttpPost("export")]
    public IActionResult Export([FromBody] DataTable data)
    {
        var bytes = _excelService.ExportToExcel(data);
        return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "export.xlsx");
    }
}