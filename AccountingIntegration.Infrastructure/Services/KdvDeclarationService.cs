using AccountingIntegration.Application.Services;
using System.Text;

namespace AccountingIntegration.Infrastructure.Services;

public class KdvDeclarationService : IKdvDeclarationService
{
    public string GenerateKdvDeclaration(object invoiceData)
    {
        // Simplified KDV declaration XML generator
        // In real scenario, map invoice totals, calculate 1%, 8%, 18% KDV etc.
        var sb = new StringBuilder();
        sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        sb.AppendLine("<KdvBeyanname>");
        sb.AppendLine("  <Donem>2026-05</Donem>");
        sb.AppendLine("  <ToplamTutar>0</ToplamTutar>");
        sb.AppendLine("  <Kdv1>0</Kdv1>");
        sb.AppendLine("  <Kdv8>0</Kdv8>");
        sb.AppendLine("  <Kdv18>0</Kdv18>");
        sb.AppendLine("</KdvBeyanname>");
        return sb.ToString();
    }
}