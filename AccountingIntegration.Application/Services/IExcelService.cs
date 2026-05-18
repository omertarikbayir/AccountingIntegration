using ClosedXML.Excel;
using System.Data;

namespace AccountingIntegration.Application.Services;

public interface IExcelService
{
    DataTable ImportExcel(Stream excelStream, string sheetName = "Sheet1");
    byte[] ExportToExcel(DataTable dataTable, string sheetName = "Sheet1");
    bool ValidateExcel(DataTable dataTable, out List<string> errors);
}