namespace AccountingIntegration.Application.Services;

public interface IOcrService
{
    string ExtractTextFromPdf(Stream pdfStream, string language = "tur+eng");
}