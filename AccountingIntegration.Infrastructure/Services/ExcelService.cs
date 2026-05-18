using AccountingIntegration.Application.Services;
using ClosedXML.Excel;
using System.Data;

namespace AccountingIntegration.Infrastructure.Services;

public class ExcelService : IExcelService
{
    public DataTable ImportExcel(Stream excelStream, string sheetName = "Sheet1")
    {
        using var workbook = new XLWorkbook(excelStream);
        var worksheet = workbook.Worksheet(sheetName);
        var dataTable = new DataTable();

        // Read headers
        var firstRow = worksheet.FirstRowUsed();
        foreach (var cell in firstRow.CellsUsed())
        {
            dataTable.Columns.Add(cell.GetString());
        }

        // Read data rows
        foreach (var row in worksheet.RowsUsed().Skip(1))
        {
            var dataRow = dataTable.NewRow();
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                dataRow[i] = row.Cell(i + 1).GetString();
            }
            dataTable.Rows.Add(dataRow);
        }

        return dataTable;
    }

    public byte[] ExportToExcel(DataTable dataTable, string sheetName = "Sheet1")
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add(sheetName);

        // Add headers
        for (int i = 0; i < dataTable.Columns.Count; i++)
        {
            worksheet.Cell(1, i + 1).Value = dataTable.Columns[i].ColumnName;
        }

        // Add data
        for (int row = 0; row < dataTable.Rows.Count; row++)
        {
            for (int col = 0; col < dataTable.Columns.Count; col++)
            {
                worksheet.Cell(row + 2, col + 1).Value = dataTable.Rows[row][col]?.ToString();
            }
        }

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }

    public bool ValidateExcel(DataTable dataTable, out List<string> errors)
    {
        errors = new List<string>();
        // Basic validation example
        if (dataTable.Rows.Count == 0)
            errors.Add("Dosyada veri bulunamadı.");

        return errors.Count == 0;
    }
}