namespace AccountingIntegration.Application.Services;

public interface IXmlTransformationService
{
    string TransformXml(string xmlContent, string xsltContent);
}