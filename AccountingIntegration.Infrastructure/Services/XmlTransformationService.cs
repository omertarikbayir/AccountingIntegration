using AccountingIntegration.Application.Services;
using System.Xml;
using System.Xml.Xsl;
using System.IO;

namespace AccountingIntegration.Infrastructure.Services;

public class XmlTransformationService : IXmlTransformationService
{
    public string TransformXml(string xmlContent, string xsltContent)
    {
        var xslt = new XslCompiledTransform();
        using var xsltReader = XmlReader.Create(new StringReader(xsltContent));
        xslt.Load(xsltReader);

        using var xmlReader = XmlReader.Create(new StringReader(xmlContent));
        using var stringWriter = new StringWriter();
        using var xmlWriter = XmlWriter.Create(stringWriter);

        xslt.Transform(xmlReader, xmlWriter);
        return stringWriter.ToString();
    }
}