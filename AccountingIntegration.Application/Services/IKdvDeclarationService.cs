namespace AccountingIntegration.Application.Services;

public interface IKdvDeclarationService
{
    string GenerateKdvDeclaration(object invoiceData);
}