using AccountingIntegration.Infrastructure.Services;
using Xunit;

namespace AccountingIntegration.Tests;

public class ExcelServiceTests
{
    [Fact]
    public void ValidateExcel_EmptyData_ReturnsFalse()
    {
        var service = new ExcelService();
        var dt = new System.Data.DataTable();
        var isValid = service.ValidateExcel(dt, out var errors);
        Assert.False(isValid);
        Assert.NotEmpty(errors);
    }
}