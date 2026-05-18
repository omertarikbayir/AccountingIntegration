using AccountingIntegration.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountingIntegration.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class XmlController : ControllerBase
{
    private readonly IXmlTransformationService _xmlService;

    public XmlController(IXmlTransformationService xmlService)
    {
        _xmlService = xmlService;
    }

    [HttpPost("transform")]
    public IActionResult Transform([FromBody] TransformRequest request)
    {
        var result = _xmlService.TransformXml(request.XmlContent, request.XsltContent);
        return Ok(new { TransformedXml = result });
    }
}

public record TransformRequest(string XmlContent, string XsltContent);