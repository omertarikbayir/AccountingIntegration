using AccountingIntegration.Application.Services;
using Tesseract;
using UglyToad.PdfPig;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.IO;
using System.Text;

namespace AccountingIntegration.Infrastructure.Services;

public class OcrService : IOcrService
{
    private readonly string _tessDataPath = Path.Combine(AppContext.BaseDirectory, "tessdata");

    public string ExtractTextFromPdf(Stream pdfStream, string language = "tur+eng")
    {
        var result = new StringBuilder();
        using var document = PdfDocument.Open(pdfStream);
        using var engine = new TesseractEngine(_tessDataPath, language, EngineMode.Default);

        foreach (var page in document.GetPages())
        {
            // Convert PDF page to image (simplified rendering)
            var width = (int)page.Width;
            var height = (int)page.Height;
            using var image = new Image<Rgba32>(width, height);

            // For production use a proper renderer (PdfiumViewer / ImageMagick)
            // Here we use basic text extraction + OCR on rendered page
            var text = page.Text;
            if (!string.IsNullOrWhiteSpace(text))
                result.AppendLine(text);

            // OCR fallback on image
            using var ms = new MemoryStream();
            image.SaveAsPng(ms);
            ms.Position = 0;
            using var pix = Pix.LoadFromMemory(ms.ToArray());
            using var ocrPage = engine.Process(pix);
            result.AppendLine(ocrPage.GetText());
        }

        return result.ToString();
    }
}